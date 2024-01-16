using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsApp1

{
    public partial class Form1 : Form
    {

        private SerialPort serialPort = new SerialPort();
        private Stopwatch stopwatch = new Stopwatch();
        private Stopwatch stopwatch2 = new Stopwatch();
        private int maxSeconds = 15;
        private double t; // Time elapsed in seconds
        private DateTime startTime = DateTime.Now;


        // Define the static Y-axis limits
        private double yAxisMinimum = -100.0;
        private double yAxisMaximum = 100.0;
        private string pcString = "X";
        private string buttonState = "R";

        // OxyPlot model and series
        private PlotModel plotModel;
        private LineSeries pendulumAngleSeries;
        private LineSeries motorArmAngleSeries;

        private List<OxyPlot.DataPoint> pendulumDataPoints = new List<OxyPlot.DataPoint>();
        private List<OxyPlot.DataPoint> motorArmDataPoints = new List<OxyPlot.DataPoint>();

        private bool isConnected = false;
        private bool startFlag = false;
        private bool commandFlag = false;
        private bool acquireData = false;
        private int fileIndex = 0;
        private StreamWriter dataStreamWriter;
        private string K1, K2, I1, I2, D1, D2, Dz1, Dz2, A1, VL;
        double time = 0;
        double val1, val2;
        double offset = 0;

        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<int>();


        string serialDataString = "";
        bool connected;
        Int32 numByte_global = 0;
        int a_state = -1;
        const double STEPS_TO_DEG = 0.04394531;


        public Form1()
        {
            InitializeComponent();
            EnableControls(false);
            InitializePlot();
            populateTextBoxes();
        }
        private void btnConnectDevice_Click_1(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.DataReceived += SerialPort_DataReceived;
                btnConnectDevice.Text = "Disconnect Pendulum";
                ConnectDevice();

            }

            else
            {
                btnConnectDevice.Text = "Connect Pendulum";
                serialPort.Close();
            }
        }

        private void ConnectDevice()
        {
            try
            {
                OpenSerialPort(serialPort, "COM4", 115200);
                startTime = DateTime.Now;


                EnableControls(true); // Enable controls when the device is connected
                if (serialPort.IsOpen)
                    MessageBox.Show("Serial port successfully opened. Device connected.");

                // Set the isConnected flag to true to indicate successful connection
                isConnected = true;
                stopwatch.Start();
                serialPort.DiscardInBuffer();

                // No need to start the timer here
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the serial device: " + ex.Message);
            }
        }

        private void SaveDataToCsv(double val1, double val2)
        {
            string fileName = "test" + fileIndex + ".csv";

            using (StreamWriter writer = new StreamWriter(fileName, true)) // Append to the existing file
            {
                if (fileIndex == 1)
                {
                    writer.WriteLine("Time, Pendulum Angle, Motor Arm Angle");
                }

                double time = stopwatch.Elapsed.TotalSeconds;
                writer.WriteLine($"{time}, {val1}, {val2}");
            } // The using block automatically closes the file when it's done
        }


        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                // Read the data from the serial port and parse the message
                string message = serialPort.ReadLine();
                string[] values = message.Split('A', 'Z');


                if (values.Length == 3)
                {
                    val1 = double.Parse(values[0]) * STEPS_TO_DEG;
                    val2 = double.Parse(values[1]) * STEPS_TO_DEG;

                    // Update the data array and reassign it to the series

                    tuningMessage();
                    UpdateSeriesData(val1, val2);


                    if (dataStreamWriter != null)
                    {
                        // Save data to a CSV file
                        time += 0.01;
                        dataStreamWriter.WriteLine($"{time}, {val1}, {val2}");
                        dataStreamWriter.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., display an error message)
                MessageBox.Show("Error updating the chart: " + ex.Message);
            }

        }

        private void UpdateSeriesData(double val1, double val2)
        {
            double time = stopwatch.Elapsed.TotalSeconds;


            // Create new data points
            OxyPlot.DataPoint pendulumDataPoint = new OxyPlot.DataPoint(time, val2);
            OxyPlot.DataPoint motorArmDataPoint = new OxyPlot.DataPoint(time, val1);

            // Add the data points to the lists
            pendulumDataPoints.Add(pendulumDataPoint);
            motorArmDataPoints.Add(motorArmDataPoint);

            // Update the series with the new data
            pendulumAngleSeries.ItemsSource = pendulumDataPoints;
            motorArmAngleSeries.ItemsSource = motorArmDataPoints;


            // Calculate the new Y-axis limits with 10% headroom
            yAxisMinimum = Math.Min(-15, motorArmDataPoints.Min(point => point.Y));
            yAxisMaximum = Math.Max(15, motorArmDataPoints.Max(point => point.Y));

            // Update the Y-axis limits in OxyPlot model
            plotModel.Axes[1].Minimum = yAxisMinimum;
            plotModel.Axes[1].Maximum = yAxisMaximum;
            

            // Adjust the X-axis dynamically based on t
            double xMin = (time < maxSeconds) ? 0 : (time - maxSeconds);
            double xMax = (time < maxSeconds) ? maxSeconds : time + 2;
            plotModel.Axes[0].Minimum = xMin;
            plotModel.Axes[0].Maximum = xMax;

            // Remove old data points if more than 10 seconds shown
            double xMinRemove = time - maxSeconds;
            pendulumDataPoints.RemoveAll(p => p.X < xMinRemove);
            motorArmDataPoints.RemoveAll(p => p.X < xMinRemove);

            // Invalidate the plot to trigger a redraw
            plotView.InvalidatePlot(true);
        }


        private bool OpenSerialPort(SerialPort serialObj, string portName, int baudRate)
        {
            try
            {
                // Check if the serial port is already open
                if (serialObj.IsOpen)
                {
                    // If it's already open, close it first before reopening
                    serialObj.Close();
                }

                // Configure the serial port
                serialObj.PortName = portName;
                serialObj.BaudRate = baudRate;
                serialObj.DataBits = 8;
                serialObj.Parity = Parity.None;
                serialObj.StopBits = StopBits.One;

                // Open the serial port
                serialObj.Open();

                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the port opening
                MessageBox.Show("Error opening the serial port: " + ex.Message);
                return false;
            }
        }

        private void InitializePlot()
        {
            // Set up the OxyPlot model
            plotModel = new PlotModel { Title = "Real-Time Plot" };

            // Set up the X-axis as time in seconds using a LinearAxis
            plotModel.Axes.Add(new LinearAxis
            {
                Title = "Time (s)",
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = maxSeconds,
                MajorStep = 1, // Customize this based on your preference
                MajorGridlineStyle = LineStyle.Solid, // Add this line for X-axis grid lines
                MajorGridlineColor = OxyColor.FromRgb(200, 200, 200) // Customize grid line color
            });

            // Set up the Y-axis as your desired range
            plotModel.Axes.Add(new LinearAxis
            {
                Title = "Value",
                Position = AxisPosition.Left,
                Minimum = yAxisMinimum,
                Maximum = yAxisMaximum,
                MajorStep = 20,
                MajorGridlineStyle = LineStyle.Solid, // Add this line for Y-axis grid lines
                MajorGridlineColor = OxyColor.FromRgb(200, 200, 200) // Customize grid line color
            });

            // Create the "Pendulum Angle" series
            pendulumAngleSeries = new LineSeries
            {
                Title = "Pendulum Angle",
                ItemsSource = pendulumDataPoints // Set the ItemsSource to the list of data points
            };
            plotModel.Series.Add(pendulumAngleSeries);

            // Create the "Motor Arm Angle" series
            motorArmAngleSeries = new LineSeries
            {
                Title = "Motor Arm Angle",
                ItemsSource = motorArmDataPoints // Set the ItemsSource to the list of data points
            };
            plotModel.Series.Add(motorArmAngleSeries);

            // Add legend to the plot model
            var legend = new OxyPlot.Legends.Legend
            {
                LegendPosition = LegendPosition.TopLeft, // Customize legend position
                LegendPlacement = LegendPlacement.Outside,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendItemOrder = OxyPlot.Legends.LegendItemOrder.Reverse,
                LegendSymbolLength = 24 // Customize symbol length
            };
            plotModel.Legends.Add(legend);

            // Assign the model to the PlotView control
            plotView.Model = plotModel;
        }

        private void DisconnectDevice()
        {
            if (serialPort.IsOpen)
            {
                serialPort.DiscardInBuffer(); // Clear the serial port buffer
                serialPort.Close();
                EnableControls(false); // Disable controls when the device is disconnected

                // Clear the data point lists
                pendulumDataPoints.Clear();
                motorArmDataPoints.Clear();
            }
        }

        // Enable or disable controls based on the connection status
        private void EnableControls(bool connected)
        {

            swingUp.Enabled = connected;
            swingDown.Enabled = connected;
            minus_sixty.Enabled = connected;
            plus_sixty.Enabled = connected;
            startButton.Enabled = connected;
            stopButton.Enabled = connected;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectDevice(); // Close the serial connection before the form is closed
        }

        private void sliderVals()
        {
            int intDz1 = Convert.ToInt32(1000 * mapVals(dz1.Value, 0, 30, 2, 3.25));
            int intD1 = Convert.ToInt32(1000 * mapVals(d1.Value, 0, 30, 0.02, 0.4));
            int intD2 = Convert.ToInt32(1000 * mapVals(d2.Value, 0, 30, 0.02, 0.2));
            int intK1 = Convert.ToInt32(1000 * mapVals(k1.Value, 0, 30, 0.2, 2));
            int intK2 = Convert.ToInt32(1000 * mapVals(k2.Value, 0, 30, 0.03, 0.3));
            int intI1 = Convert.ToInt32(1000 * mapVals(i1.Value, 0, 30, 0, 0.2));
            int intI2 = Convert.ToInt32(1000 * mapVals(i2.Value, 0, 30, 0, 0.2));

            // Convert to strings
            Dz1 = intDz1.ToString();
            D1 = intD1.ToString();
            D2 = intD2.ToString();
            K1 = intK1.ToString();
            K2 = intK2.ToString();
            I1 = intI1.ToString();
            I2 = intI2.ToString();
            VL = voltageLimit.Value.ToString();
        }


        private double mapVals(int sliderVal, double fromLow, double fromHigh, double toLow, double toHigh)
        {

            return ((double)sliderVal - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }

        private void populateTextBoxes()
        {
            sliderVals();
            dz1T.Text = Dz1;
            d1T.Text = D1;
            d2T.Text = D2;
            i1T.Text = I1;
            i2T.Text = I2;
            p1T.Text = K1;
            p2T.Text = K2;
            voltageLimitText.Text = VL;
        }

        private void tuningMessage()
        {

            List<string> messages = new List<string>();
            string fullMessage = "P";
            messages.Add(K1);
            messages.Add(I1);
            messages.Add(D1);
            messages.Add(K2);
            messages.Add(I2);
            messages.Add(D2);
            messages.Add(Dz1);
            messages.Add(VL);

            for (int i = 0; i < 8; i++)
            {
                fullMessage += messages[i];
                fullMessage += "A";
            }

            fullMessage += "Z";

            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(fullMessage);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending data through serial port: " + ex.Message);
                }
            }
        }

        private void commandMessage()
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(buttonState);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending data through serial port: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonState = "A";
            commandMessage();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            buttonState = "P";
            commandMessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonState = "U";
            offset = val1;
            commandMessage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonState = "D";
            commandMessage();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttonState = "W";
            commandMessage();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            buttonState = "Y";
            commandMessage();
        }

        private void plus_sixty_Click(object sender, EventArgs e)
        {
            buttonState = "J";
            commandMessage();
        }

        private void k1_Scroll(object sender, EventArgs e)
        {
            sliderVals();
            p1T.Text = K1;

        }

        private void d2_Scroll(object sender, EventArgs e)
        {
            sliderVals();
            d2T.Text = D2;

        }

        private void i2_Scroll(object sender, EventArgs e)
        {
            sliderVals();
            i2T.Text = I2;

        }

        private void k2_Scroll(object sender, EventArgs e)
        {
            sliderVals();
            p2T.Text = K2;

        }

        private void i1_Scroll(object sender, EventArgs e)
        {
            sliderVals();
            i1T.Text = I1;


        }

        private void d1_Scroll(object sender, EventArgs e)
        {
            sliderVals();
            d1T.Text = D1;

        }

        private void dz1_Scroll(object sender, EventArgs e)
        {
            sliderVals();
            dz1T.Text = Dz1;


        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            buttonState = "F";
            commandFlag = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            fileIndex++;
            string fileName = "test" + fileIndex + ".csv";
            dataStreamWriter = new StreamWriter(fileName, true); // Use the class-level StreamWriter

            // Enable the Stop button and disable the Start button
            startButton.Enabled = false;
            stopButton.Enabled = true;
            acquireData = true;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            acquireData = false;
            // Close the StreamWriter
            if (dataStreamWriter != null)
            {
                dataStreamWriter.Close();
                dataStreamWriter.Dispose();
                dataStreamWriter = null;
            }

            // Enable the Start button and disable the Stop button
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void voltageLimit_Scroll(object sender, EventArgs e)
        {
            sliderVals();
            voltageLimitText.Text = VL;
        }
    }
}










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
        private SerialPort serialPortAcc = new SerialPort();
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
        private string K1, K2, I1, I2, D1, D2, Dz1, Dz2, A1;
        double time = 0;

        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<int>();
 

        string serialDataString = "";
        bool connected;
        Int32 numByte_global = 0;
        int a_state = -1;


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
                ConnectDevice();
            }
        }

        private void ConnectDevice()
        {
            try
            {
                OpenSerialPort(serialPort, "COM3", 115200);
                OpenSerialPort(serialPortAcc, "COM4", 9600);
                startTime = DateTime.Now;

                // Clear the serial port buffer by reading and discarding any existing data
                //while (serialPort.BytesToRead > 0)
                //{
                //    serialPort.ReadLine();
                //}



                EnableControls(true); // Enable controls when the device is connected
                MessageBox.Show("Serial port successfully opened. Device connected.");

                // Set the isConnected flag to true to indicate successful connection
                isConnected = true;
                stopwatch.Start();
                serialPort.DiscardInBuffer();
                serialPortAcc.DiscardInBuffer();
                serialPort.DataReceived += SerialPort_DataReceived;
                serialPortAcc.DataReceived += SerialPortAcc_DataRecieved;
                timerAcc.Start();
                timerAcc.Enabled = true;

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
                    double val1 = double.Parse(values[0]);
                    double val2 = double.Parse(values[1]);


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

        private void SerialPortAcc_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            int numBytes;
            int newByte = 0;

            numBytes = serialPortAcc.BytesToRead;

            while (numBytes != 0)
            {
                newByte = serialPortAcc.ReadByte();
                dataQueue.Enqueue(Convert.ToInt32(newByte));
                numBytes = serialPortAcc.BytesToRead;
            }

        }

        private void timerAcc_Tick_1(object sender, EventArgs e)
        {
            if (serialPortAcc.IsOpen)
            {
                int x, y, z = 0;
                int currByte;

                while (dataQueue.TryDequeue(out currByte))
                {

                    if (a_state == 0)
                    {
                        Ax.Text = currByte.ToString();
                        a_state = 1;
                    }
                    else if (a_state == 1)
                    {
                        Ay.Text = currByte.ToString();
                        a_state = 2;
                    }
                    else if (a_state == 2)
                    {
                        Az.Text = currByte.ToString();
                        a_state = 3;
                    }

                    if (currByte == 255)
                    {
                        a_state = 0;
                    }

                }

                getOrientation(Convert.ToInt32(Ax.Text), Convert.ToInt32(Ay.Text), Convert.ToInt32(Az.Text));
            }
        }

        private void getOrientation(Int32 x, Int32 y, Int32 z)
        {

            double xnorm = (x - 125) / 25.0;
            double ynorm = (y - 125) / 25.0;
            double znorm = (z - 125) / 25.0;

            double pitchRadian = Math.Atan2(xnorm, Math.Sqrt(ynorm * ynorm + znorm * znorm) + 0.001);
            double Pitch = RadiansToDegrees(pitchRadian);

            double rollRadian = Math.Atan2(ynorm, Math.Sqrt(xnorm * xnorm + znorm * znorm) + 0.001);
            double Roll = RadiansToDegrees(rollRadian);

            double thetaRadian = Math.Atan2(Math.Sqrt(xnorm * xnorm + ynorm * ynorm), znorm + 0.001);
            double Theta = RadiansToDegrees(thetaRadian);

            targetAngle.Text = Pitch.ToString();

        }

        private double RadiansToDegrees(double radians)
        {
            return radians * (180.0 / Math.PI);
        }

        private void UpdateSeriesData(double val1, double val2)
        {
            double time = stopwatch.Elapsed.TotalSeconds;


            // Create new data points
            OxyPlot.DataPoint pendulumDataPoint = new OxyPlot.DataPoint(time, val1);
            OxyPlot.DataPoint motorArmDataPoint = new OxyPlot.DataPoint(time, val2);

            // Add the data points to the lists
            pendulumDataPoints.Add(pendulumDataPoint);
            motorArmDataPoints.Add(motorArmDataPoint);

            // Update the series with the new data
            pendulumAngleSeries.ItemsSource = pendulumDataPoints;
            motorArmAngleSeries.ItemsSource = motorArmDataPoints;

            // Check if either value exceeds the bounds of -10 to 10
            if (val1 < -10 || val1 > 10 || val2 < -10 || val2 > 10)
            {
                // Calculate the new Y-axis limits with 10% headroom
                yAxisMinimum = -100;
                yAxisMaximum = 100;

                // Update the Y-axis limits in OxyPlot model
                plotModel.Axes[1].Minimum = yAxisMinimum;
                plotModel.Axes[1].Maximum = yAxisMaximum;
            }

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
                serialPortAcc.DiscardInBuffer();
                serialPortAcc.Close();
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
            zeroArm.Enabled = connected;
            zeroPend.Enabled = connected;
            swingUpImpulse.Enabled = connected;
            minus_sixty.Enabled = connected;
            plus_sixty.Enabled = connected;
            startButton.Enabled = connected;
            stopButton.Enabled = connected;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerAcc.Stop(); // Stop the timer before closing the form
            DisconnectDevice(); // Close the serial connection before the form is closed
        }


        private void sendCommand()
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(pcString + buttonState + "D");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending data through serial port: " + ex.Message);
                }
            }
        }

        private void sliderVals()
        {
            Dz1 = mapVals(dz1.Value, 0, 30, 2, 3.25).ToString("F3");
            Dz2 = mapVals(dz2.Value, 0, 30, 2, 3.25).ToString("F3");
            D1 = mapVals(d1.Value, 0, 30, 0.02, 0.2).ToString("F3");
            D2 = mapVals(d2.Value, 0, 30, 0.02, 0.2).ToString("F3");
            K1 = mapVals(k1.Value, 0, 30, 0.1, 1).ToString("F3");
            K2 = mapVals(k2.Value, 0, 30, 0.03, 0.3).ToString("F3");
            I1 = mapVals(i1.Value, 0, 30, 0, 0.2).ToString("F3");
            I2 = mapVals(i2.Value, 0, 30, 0, 0.2).ToString("F3");

        }

        private double mapVals(int sliderVal, double fromLow, double fromHigh, double toLow, double toHigh)
        {

            return ((double)sliderVal - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }

        private void populateTextBoxes()
        {
            sliderVals();
            dz1T.Text = Dz1;
            dz2T.Text = Dz2;
            d1T.Text = D1;
            d2T.Text = D2;
            i1T.Text = I1;
            i2T.Text = I2;
            p1T.Text = K1;
            p2T.Text = K2;
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
            messages.Add(Dz2);
            messages.Add(targetAngle.Text);
            messages.Add(buttonState);

            for (int i = 0; i < 10; i++)
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
                    if (buttonState != "R")
                    {
                        commandFlag = false;
                    }

                    if (!commandFlag)
                    {
                        buttonState = "R";
                    }
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
            commandFlag = true;

        }


        private void button4_Click(object sender, EventArgs e)
        {
            buttonState = "P";
            commandFlag = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonState = "U";
            commandFlag = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonState = "D";
            commandFlag = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttonState = "W";
            commandFlag = true;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            buttonState = "Y";
            commandFlag = true;

        }

        private void plus_sixty_Click(object sender, EventArgs e)
        {
            buttonState = "J";
            commandFlag = true;

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

        private void dz2_Scroll(object sender, EventArgs e)
        {
            sliderVals();
            dz2T.Text = Dz2;


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

    }
}










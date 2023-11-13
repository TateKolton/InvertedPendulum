namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            zeroArm = new Button();
            swingUp = new Button();
            swingDown = new Button();
            zeroPend = new Button();
            btnConnectDevice = new Button();
            label1 = new Label();
            minus_sixty = new Button();
            plus_sixty = new Button();
            plotView = new OxyPlot.WindowsForms.PlotView();
            d1 = new TrackBar();
            i1 = new TrackBar();
            k1 = new TrackBar();
            d2 = new TrackBar();
            i2 = new TrackBar();
            k2 = new TrackBar();
            dz2 = new TrackBar();
            dz1 = new TrackBar();
            p1T = new TextBox();
            i1T = new TextBox();
            d1T = new TextBox();
            d2T = new TextBox();
            i2T = new TextBox();
            p2T = new TextBox();
            dz2T = new TextBox();
            dz1T = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            swingUpImpulse = new Button();
            stopButton = new Button();
            startButton = new Button();
            Ax = new TextBox();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            Ay = new TextBox();
            label15 = new Label();
            Az = new TextBox();
            label16 = new Label();
            label17 = new Label();
            targetAngle = new TextBox();
            timerAcc = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)d1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)i1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)k1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)d2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)i2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)k2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dz2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dz1).BeginInit();
            SuspendLayout();
            // 
            // zeroArm
            // 
            zeroArm.Location = new Point(1163, 215);
            zeroArm.Margin = new Padding(4, 5, 4, 5);
            zeroArm.Name = "zeroArm";
            zeroArm.Size = new Size(143, 43);
            zeroArm.TabIndex = 0;
            zeroArm.TabStop = false;
            zeroArm.Text = "Zero Arm";
            zeroArm.UseVisualStyleBackColor = true;
            zeroArm.Click += button1_Click;
            // 
            // swingUp
            // 
            swingUp.Location = new Point(1131, 341);
            swingUp.Margin = new Padding(4, 5, 4, 5);
            swingUp.Name = "swingUp";
            swingUp.Size = new Size(203, 122);
            swingUp.TabIndex = 1;
            swingUp.TabStop = false;
            swingUp.Text = "Energy Swing Up";
            swingUp.UseVisualStyleBackColor = true;
            swingUp.Click += button2_Click;
            // 
            // swingDown
            // 
            swingDown.Location = new Point(1131, 637);
            swingDown.Margin = new Padding(4, 5, 4, 5);
            swingDown.Name = "swingDown";
            swingDown.Size = new Size(203, 122);
            swingDown.TabIndex = 2;
            swingDown.TabStop = false;
            swingDown.Text = "Swing Down";
            swingDown.UseVisualStyleBackColor = true;
            swingDown.Click += button3_Click;
            // 
            // zeroPend
            // 
            zeroPend.Location = new Point(1163, 269);
            zeroPend.Margin = new Padding(4, 5, 4, 5);
            zeroPend.Name = "zeroPend";
            zeroPend.Size = new Size(143, 43);
            zeroPend.TabIndex = 6;
            zeroPend.TabStop = false;
            zeroPend.Text = "Zero Pendulum";
            zeroPend.UseVisualStyleBackColor = true;
            zeroPend.Click += button4_Click;
            // 
            // btnConnectDevice
            // 
            btnConnectDevice.Location = new Point(1131, 42);
            btnConnectDevice.Margin = new Padding(4, 5, 4, 5);
            btnConnectDevice.Name = "btnConnectDevice";
            btnConnectDevice.Size = new Size(203, 155);
            btnConnectDevice.TabIndex = 9;
            btnConnectDevice.TabStop = false;
            btnConnectDevice.Text = "Connect Device";
            btnConnectDevice.UseVisualStyleBackColor = true;
            btnConnectDevice.Click += btnConnectDevice_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(300, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 65);
            label1.TabIndex = 10;
            // 
            // minus_sixty
            // 
            minus_sixty.Location = new Point(1130, 778);
            minus_sixty.Margin = new Padding(4, 5, 4, 5);
            minus_sixty.Name = "minus_sixty";
            minus_sixty.Size = new Size(99, 43);
            minus_sixty.TabIndex = 12;
            minus_sixty.TabStop = false;
            minus_sixty.Text = "-90";
            minus_sixty.UseVisualStyleBackColor = true;
            minus_sixty.Click += button1_Click_1;
            // 
            // plus_sixty
            // 
            plus_sixty.Location = new Point(1238, 778);
            plus_sixty.Margin = new Padding(4, 5, 4, 5);
            plus_sixty.Name = "plus_sixty";
            plus_sixty.Size = new Size(96, 43);
            plus_sixty.TabIndex = 13;
            plus_sixty.TabStop = false;
            plus_sixty.Text = "+90";
            plus_sixty.UseVisualStyleBackColor = true;
            plus_sixty.Click += plus_sixty_Click;
            // 
            // plotView
            // 
            plotView.Location = new Point(47, 125);
            plotView.Margin = new Padding(4, 5, 4, 5);
            plotView.Name = "plotView";
            plotView.PanCursor = Cursors.Hand;
            plotView.Size = new Size(1013, 817);
            plotView.TabIndex = 14;
            plotView.Text = "plotView1";
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // d1
            // 
            d1.Location = new Point(1711, 133);
            d1.Margin = new Padding(4, 5, 4, 5);
            d1.Maximum = 30;
            d1.Name = "d1";
            d1.Orientation = Orientation.Vertical;
            d1.Size = new Size(69, 247);
            d1.TabIndex = 20;
            d1.Value = 5;
            d1.Scroll += d1_Scroll;
            // 
            // i1
            // 
            i1.Location = new Point(1547, 133);
            i1.Margin = new Padding(4, 5, 4, 5);
            i1.Maximum = 30;
            i1.Name = "i1";
            i1.Orientation = Orientation.Vertical;
            i1.Size = new Size(69, 247);
            i1.TabIndex = 19;
            i1.Scroll += i1_Scroll;
            // 
            // k1
            // 
            k1.Location = new Point(1396, 133);
            k1.Margin = new Padding(4, 5, 4, 5);
            k1.Maximum = 30;
            k1.Name = "k1";
            k1.Orientation = Orientation.Vertical;
            k1.Size = new Size(69, 247);
            k1.TabIndex = 18;
            k1.Value = 10;
            k1.Scroll += k1_Scroll;
            // 
            // d2
            // 
            d2.Location = new Point(1711, 552);
            d2.Margin = new Padding(4, 5, 4, 5);
            d2.Maximum = 30;
            d2.Name = "d2";
            d2.Orientation = Orientation.Vertical;
            d2.Size = new Size(69, 247);
            d2.TabIndex = 23;
            d2.Value = 5;
            d2.Scroll += d2_Scroll;
            // 
            // i2
            // 
            i2.Location = new Point(1547, 552);
            i2.Margin = new Padding(4, 5, 4, 5);
            i2.Maximum = 30;
            i2.Name = "i2";
            i2.Orientation = Orientation.Vertical;
            i2.Size = new Size(69, 247);
            i2.TabIndex = 22;
            i2.Value = 4;
            i2.Scroll += i2_Scroll;
            // 
            // k2
            // 
            k2.Location = new Point(1396, 552);
            k2.Margin = new Padding(4, 5, 4, 5);
            k2.Maximum = 30;
            k2.Name = "k2";
            k2.Orientation = Orientation.Vertical;
            k2.Size = new Size(69, 247);
            k2.TabIndex = 21;
            k2.Value = 10;
            k2.Scroll += k2_Scroll;
            // 
            // dz2
            // 
            dz2.Location = new Point(1964, 322);
            dz2.Margin = new Padding(4, 5, 4, 5);
            dz2.Maximum = 30;
            dz2.Name = "dz2";
            dz2.Orientation = Orientation.Vertical;
            dz2.Size = new Size(69, 247);
            dz2.TabIndex = 25;
            dz2.Value = 17;
            dz2.Scroll += dz2_Scroll;
            // 
            // dz1
            // 
            dz1.Location = new Point(1843, 322);
            dz1.Margin = new Padding(4, 5, 4, 5);
            dz1.Maximum = 30;
            dz1.Name = "dz1";
            dz1.Orientation = Orientation.Vertical;
            dz1.Size = new Size(69, 247);
            dz1.TabIndex = 24;
            dz1.Value = 17;
            dz1.Scroll += dz1_Scroll;
            // 
            // p1T
            // 
            p1T.Location = new Point(1370, 390);
            p1T.Margin = new Padding(4, 5, 4, 5);
            p1T.Name = "p1T";
            p1T.Size = new Size(88, 31);
            p1T.TabIndex = 26;
            // 
            // i1T
            // 
            i1T.Location = new Point(1521, 390);
            i1T.Margin = new Padding(4, 5, 4, 5);
            i1T.Name = "i1T";
            i1T.Size = new Size(88, 31);
            i1T.TabIndex = 27;
            // 
            // d1T
            // 
            d1T.Location = new Point(1686, 390);
            d1T.Margin = new Padding(4, 5, 4, 5);
            d1T.Name = "d1T";
            d1T.Size = new Size(88, 31);
            d1T.TabIndex = 28;
            // 
            // d2T
            // 
            d2T.Location = new Point(1686, 808);
            d2T.Margin = new Padding(4, 5, 4, 5);
            d2T.Name = "d2T";
            d2T.Size = new Size(88, 31);
            d2T.TabIndex = 31;
            // 
            // i2T
            // 
            i2T.Location = new Point(1521, 808);
            i2T.Margin = new Padding(4, 5, 4, 5);
            i2T.Name = "i2T";
            i2T.Size = new Size(88, 31);
            i2T.TabIndex = 30;
            // 
            // p2T
            // 
            p2T.Location = new Point(1370, 808);
            p2T.Margin = new Padding(4, 5, 4, 5);
            p2T.Name = "p2T";
            p2T.Size = new Size(88, 31);
            p2T.TabIndex = 29;
            // 
            // dz2T
            // 
            dz2T.Location = new Point(1950, 582);
            dz2T.Margin = new Padding(4, 5, 4, 5);
            dz2T.Name = "dz2T";
            dz2T.Size = new Size(88, 31);
            dz2T.TabIndex = 33;
            // 
            // dz1T
            // 
            dz1T.Location = new Point(1814, 582);
            dz1T.Margin = new Padding(4, 5, 4, 5);
            dz1T.Name = "dz1T";
            dz1T.Size = new Size(91, 31);
            dz1T.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1409, 103);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(22, 25);
            label2.TabIndex = 34;
            label2.Text = "P";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1409, 522);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(22, 25);
            label3.TabIndex = 35;
            label3.Text = "P";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1560, 522);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(17, 25);
            label4.TabIndex = 36;
            label4.Text = "I";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1560, 103);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(17, 25);
            label5.TabIndex = 37;
            label5.Text = "I";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1724, 103);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(25, 25);
            label6.TabIndex = 38;
            label6.Text = "D";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1724, 522);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(25, 25);
            label7.TabIndex = 39;
            label7.Text = "D";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(1499, 63);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(143, 35);
            label8.TabIndex = 40;
            label8.Text = "Pendulum";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(1524, 475);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(93, 35);
            label9.TabIndex = 41;
            label9.Text = "Motor";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(1863, 277);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(139, 35);
            label10.TabIndex = 42;
            label10.Text = "Deadzone";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(329, 42);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(520, 44);
            label11.TabIndex = 43;
            label11.Text = "Rotational Inverted Pendulum";
            // 
            // swingUpImpulse
            // 
            swingUpImpulse.Location = new Point(1131, 491);
            swingUpImpulse.Margin = new Padding(4, 5, 4, 5);
            swingUpImpulse.Name = "swingUpImpulse";
            swingUpImpulse.Size = new Size(203, 122);
            swingUpImpulse.TabIndex = 44;
            swingUpImpulse.TabStop = false;
            swingUpImpulse.Text = "Impulse Swing Up";
            swingUpImpulse.UseVisualStyleBackColor = true;
            swingUpImpulse.Click += button1_Click_2;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(1163, 905);
            stopButton.Margin = new Padding(4, 5, 4, 5);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(143, 43);
            stopButton.TabIndex = 46;
            stopButton.TabStop = false;
            stopButton.Text = "End Acquisition";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += button1_Click_3;
            // 
            // startButton
            // 
            startButton.Location = new Point(1163, 851);
            startButton.Margin = new Padding(4, 5, 4, 5);
            startButton.Name = "startButton";
            startButton.Size = new Size(143, 43);
            startButton.TabIndex = 45;
            startButton.TabStop = false;
            startButton.Text = "Acquire Data";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += button2_Click_1;
            // 
            // Ax
            // 
            Ax.Location = new Point(1391, 911);
            Ax.Margin = new Padding(4, 5, 4, 5);
            Ax.Name = "Ax";
            Ax.Size = new Size(81, 31);
            Ax.TabIndex = 48;
            Ax.Text = "0";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(1370, 871);
            label12.Name = "label12";
            label12.Size = new Size(322, 35);
            label12.TabIndex = 49;
            label12.Text = "Accelerometer Readouts";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(1369, 911);
            label13.Name = "label13";
            label13.Size = new Size(20, 25);
            label13.TabIndex = 50;
            label13.Text = "x";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(1484, 911);
            label14.Name = "label14";
            label14.Size = new Size(21, 25);
            label14.TabIndex = 52;
            label14.Text = "y";
            // 
            // Ay
            // 
            Ay.Location = new Point(1506, 911);
            Ay.Margin = new Padding(4, 5, 4, 5);
            Ay.Name = "Ay";
            Ay.Size = new Size(81, 31);
            Ay.TabIndex = 51;
            Ay.Text = "0";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(1605, 911);
            label15.Name = "label15";
            label15.Size = new Size(20, 25);
            label15.TabIndex = 54;
            label15.Text = "z";
            // 
            // Az
            // 
            Az.Location = new Point(1627, 911);
            Az.Margin = new Padding(4, 5, 4, 5);
            Az.Name = "Az";
            Az.Size = new Size(81, 31);
            Az.TabIndex = 53;
            Az.Text = "0";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(1792, 871);
            label16.Name = "label16";
            label16.Size = new Size(178, 35);
            label16.TabIndex = 55;
            label16.Text = "Target Angle";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(1905, 911);
            label17.Name = "label17";
            label17.Size = new Size(43, 25);
            label17.TabIndex = 57;
            label17.Text = "deg";
            // 
            // targetAngle
            // 
            targetAngle.Location = new Point(1817, 911);
            targetAngle.Margin = new Padding(4, 5, 4, 5);
            targetAngle.Name = "targetAngle";
            targetAngle.Size = new Size(81, 31);
            targetAngle.TabIndex = 56;
            // 
            // timerAcc
            // 
            timerAcc.Enabled = true;
            timerAcc.Interval = 250;
            timerAcc.Tick += timerAcc_Tick_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2067, 962);
            Controls.Add(label17);
            Controls.Add(targetAngle);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(Az);
            Controls.Add(label14);
            Controls.Add(Ay);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(Ax);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Controls.Add(swingUpImpulse);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dz2T);
            Controls.Add(dz1T);
            Controls.Add(d2T);
            Controls.Add(i2T);
            Controls.Add(p2T);
            Controls.Add(d1T);
            Controls.Add(i1T);
            Controls.Add(p1T);
            Controls.Add(dz2);
            Controls.Add(dz1);
            Controls.Add(d2);
            Controls.Add(i2);
            Controls.Add(k2);
            Controls.Add(d1);
            Controls.Add(i1);
            Controls.Add(k1);
            Controls.Add(plotView);
            Controls.Add(plus_sixty);
            Controls.Add(minus_sixty);
            Controls.Add(label1);
            Controls.Add(btnConnectDevice);
            Controls.Add(zeroPend);
            Controls.Add(swingDown);
            Controls.Add(swingUp);
            Controls.Add(zeroArm);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)d1).EndInit();
            ((System.ComponentModel.ISupportInitialize)i1).EndInit();
            ((System.ComponentModel.ISupportInitialize)k1).EndInit();
            ((System.ComponentModel.ISupportInitialize)d2).EndInit();
            ((System.ComponentModel.ISupportInitialize)i2).EndInit();
            ((System.ComponentModel.ISupportInitialize)k2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dz2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dz1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button zeroArm;
        private Button swingUp;
        private Button swingDown;
        private Button zeroPend;
        private Button btnConnectDevice;
        private Label label1;
        private Button minus_sixty;
        private Button plus_sixty;
        private OxyPlot.WindowsForms.PlotView plotView;
        private TrackBar d1;
        private TrackBar i1;
        private TrackBar k1;
        private TrackBar d2;
        private TrackBar i2;
        private TrackBar k2;
        private TrackBar dz2;
        private TrackBar dz1;
        private TextBox p1T;
        private TextBox i1T;
        private TextBox d1T;
        private TextBox d2T;
        private TextBox i2T;
        private TextBox p2T;
        private TextBox dz2T;
        private TextBox dz1T;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button swingUpImpulse;
        private Button stopButton;
        private Button startButton;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private TextBox Ax;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox Ay;
        private Label label15;
        private TextBox Az;
        private Label label16;
        private Label label17;
        private TextBox targetAngle;
        private System.Windows.Forms.Timer timerAcc;
    }
}
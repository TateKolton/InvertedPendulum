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
            swingUp = new Button();
            swingDown = new Button();
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
            dz1 = new TrackBar();
            p1T = new TextBox();
            i1T = new TextBox();
            d1T = new TextBox();
            d2T = new TextBox();
            i2T = new TextBox();
            p2T = new TextBox();
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
            stopButton = new Button();
            startButton = new Button();
            label12 = new Label();
            voltageLimitText = new TextBox();
            voltageLimit = new TrackBar();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)d1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)i1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)k1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)d2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)i2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)k2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dz1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)voltageLimit).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // swingUp
            // 
            swingUp.Location = new Point(69, 319);
            swingUp.Margin = new Padding(4, 5, 4, 5);
            swingUp.Name = "swingUp";
            swingUp.Size = new Size(203, 122);
            swingUp.TabIndex = 1;
            swingUp.TabStop = false;
            swingUp.Text = "Swing Up Pendulum";
            swingUp.UseVisualStyleBackColor = true;
            swingUp.Click += button2_Click;
            // 
            // swingDown
            // 
            swingDown.Location = new Point(68, 453);
            swingDown.Margin = new Padding(4, 5, 4, 5);
            swingDown.Name = "swingDown";
            swingDown.Size = new Size(203, 122);
            swingDown.TabIndex = 2;
            swingDown.TabStop = false;
            swingDown.Text = "Swing Down Pendulum";
            swingDown.UseVisualStyleBackColor = true;
            swingDown.Click += button3_Click;
            // 
            // btnConnectDevice
            // 
            btnConnectDevice.Location = new Point(69, 151);
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
            minus_sixty.Location = new Point(68, 592);
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
            plus_sixty.Location = new Point(176, 592);
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
            plotView.Location = new Point(31, 32);
            plotView.Margin = new Padding(4, 5, 4, 5);
            plotView.Name = "plotView";
            plotView.PanCursor = Cursors.Hand;
            plotView.Size = new Size(1465, 1085);
            plotView.TabIndex = 14;
            plotView.Text = "plotView1";
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // d1
            // 
            d1.Location = new Point(692, 117);
            d1.Margin = new Padding(4, 5, 4, 5);
            d1.Maximum = 30;
            d1.Name = "d1";
            d1.Orientation = Orientation.Vertical;
            d1.Size = new Size(69, 247);
            d1.TabIndex = 20;
            d1.Value = 14;
            d1.Scroll += d1_Scroll;
            // 
            // i1
            // 
            i1.Location = new Point(528, 117);
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
            k1.Location = new Point(377, 117);
            k1.Margin = new Padding(4, 5, 4, 5);
            k1.Maximum = 30;
            k1.Name = "k1";
            k1.Orientation = Orientation.Vertical;
            k1.Size = new Size(69, 247);
            k1.TabIndex = 18;
            k1.Value = 21;
            k1.Scroll += k1_Scroll;
            // 
            // d2
            // 
            d2.Location = new Point(692, 536);
            d2.Margin = new Padding(4, 5, 4, 5);
            d2.Maximum = 30;
            d2.Name = "d2";
            d2.Orientation = Orientation.Vertical;
            d2.Size = new Size(69, 247);
            d2.TabIndex = 23;
            d2.Value = 7;
            d2.Scroll += d2_Scroll;
            // 
            // i2
            // 
            i2.Location = new Point(528, 536);
            i2.Margin = new Padding(4, 5, 4, 5);
            i2.Maximum = 30;
            i2.Name = "i2";
            i2.Orientation = Orientation.Vertical;
            i2.Size = new Size(69, 247);
            i2.TabIndex = 22;
            i2.Value = 5;
            i2.Scroll += i2_Scroll;
            // 
            // k2
            // 
            k2.Location = new Point(377, 536);
            k2.Margin = new Padding(4, 5, 4, 5);
            k2.Maximum = 30;
            k2.Name = "k2";
            k2.Orientation = Orientation.Vertical;
            k2.Size = new Size(69, 247);
            k2.TabIndex = 21;
            k2.Value = 6;
            k2.Scroll += k2_Scroll;
            // 
            // dz1
            // 
            dz1.Location = new Point(843, 306);
            dz1.Margin = new Padding(4, 5, 4, 5);
            dz1.Maximum = 30;
            dz1.Name = "dz1";
            dz1.Orientation = Orientation.Vertical;
            dz1.Size = new Size(69, 247);
            dz1.TabIndex = 24;
            dz1.Value = 16;
            dz1.Scroll += dz1_Scroll;
            // 
            // p1T
            // 
            p1T.Location = new Point(351, 374);
            p1T.Margin = new Padding(4, 5, 4, 5);
            p1T.Name = "p1T";
            p1T.Size = new Size(88, 31);
            p1T.TabIndex = 26;
            // 
            // i1T
            // 
            i1T.Location = new Point(502, 374);
            i1T.Margin = new Padding(4, 5, 4, 5);
            i1T.Name = "i1T";
            i1T.Size = new Size(88, 31);
            i1T.TabIndex = 27;
            // 
            // d1T
            // 
            d1T.Location = new Point(667, 374);
            d1T.Margin = new Padding(4, 5, 4, 5);
            d1T.Name = "d1T";
            d1T.Size = new Size(88, 31);
            d1T.TabIndex = 28;
            // 
            // d2T
            // 
            d2T.Location = new Point(667, 792);
            d2T.Margin = new Padding(4, 5, 4, 5);
            d2T.Name = "d2T";
            d2T.Size = new Size(88, 31);
            d2T.TabIndex = 31;
            // 
            // i2T
            // 
            i2T.Location = new Point(502, 792);
            i2T.Margin = new Padding(4, 5, 4, 5);
            i2T.Name = "i2T";
            i2T.Size = new Size(88, 31);
            i2T.TabIndex = 30;
            // 
            // p2T
            // 
            p2T.Location = new Point(351, 792);
            p2T.Margin = new Padding(4, 5, 4, 5);
            p2T.Name = "p2T";
            p2T.Size = new Size(88, 31);
            p2T.TabIndex = 29;
            // 
            // dz1T
            // 
            dz1T.Location = new Point(814, 566);
            dz1T.Margin = new Padding(4, 5, 4, 5);
            dz1T.Name = "dz1T";
            dz1T.Size = new Size(91, 31);
            dz1T.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(386, 87);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(22, 25);
            label2.TabIndex = 34;
            label2.Text = "P";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(386, 506);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(22, 25);
            label3.TabIndex = 35;
            label3.Text = "P";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(537, 506);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(17, 25);
            label4.TabIndex = 36;
            label4.Text = "I";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(537, 87);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(17, 25);
            label5.TabIndex = 37;
            label5.Text = "I";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(701, 87);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(25, 25);
            label6.TabIndex = 38;
            label6.Text = "D";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(701, 506);
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
            label8.Location = new Point(480, 47);
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
            label9.Location = new Point(505, 459);
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
            label10.Location = new Point(797, 261);
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
            label11.Location = new Point(1068, 32);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(520, 44);
            label11.TabIndex = 43;
            label11.Text = "Rotational Inverted Pendulum";
            // 
            // stopButton
            // 
            stopButton.Location = new Point(101, 697);
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
            startButton.Location = new Point(101, 643);
            startButton.Margin = new Padding(4, 5, 4, 5);
            startButton.Name = "startButton";
            startButton.Size = new Size(143, 43);
            startButton.TabIndex = 45;
            startButton.TabStop = false;
            startButton.Text = "Acquire Data";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += button2_Click_1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(944, 262);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(186, 35);
            label12.TabIndex = 49;
            label12.Text = "Voltage Limit";
            // 
            // voltageLimitText
            // 
            voltageLimitText.Location = new Point(988, 568);
            voltageLimitText.Margin = new Padding(4, 5, 4, 5);
            voltageLimitText.Name = "voltageLimitText";
            voltageLimitText.Size = new Size(91, 31);
            voltageLimitText.TabIndex = 48;
            // 
            // voltageLimit
            // 
            voltageLimit.Location = new Point(1010, 304);
            voltageLimit.Margin = new Padding(4, 5, 4, 5);
            voltageLimit.Maximum = 21;
            voltageLimit.Minimum = 2;
            voltageLimit.Name = "voltageLimit";
            voltageLimit.Orientation = Orientation.Vertical;
            voltageLimit.Size = new Size(69, 247);
            voltageLimit.TabIndex = 47;
            voltageLimit.Value = 6;
            voltageLimit.Scroll += voltageLimit_Scroll;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(d1);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(plus_sixty);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(minus_sixty);
            groupBox1.Controls.Add(k1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnConnectDevice);
            groupBox1.Controls.Add(voltageLimitText);
            groupBox1.Controls.Add(swingDown);
            groupBox1.Controls.Add(swingUp);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(i1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(voltageLimit);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(k2);
            groupBox1.Controls.Add(stopButton);
            groupBox1.Controls.Add(i2);
            groupBox1.Controls.Add(startButton);
            groupBox1.Controls.Add(d2);
            groupBox1.Controls.Add(dz1);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(p1T);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(i1T);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(d1T);
            groupBox1.Controls.Add(p2T);
            groupBox1.Controls.Add(i2T);
            groupBox1.Controls.Add(d2T);
            groupBox1.Controls.Add(dz1T);
            groupBox1.Location = new Point(1599, 83);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1158, 924);
            groupBox1.TabIndex = 50;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pendulum Controls";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(plotView);
            groupBox2.Location = new Point(46, 83);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1524, 1125);
            groupBox2.TabIndex = 51;
            groupBox2.TabStop = false;
            groupBox2.Text = "Real-Time Plot";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2781, 1228);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label11);
            Controls.Add(label1);
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
            ((System.ComponentModel.ISupportInitialize)dz1).EndInit();
            ((System.ComponentModel.ISupportInitialize)voltageLimit).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button swingUp;
        private Button swingDown;
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
        private TrackBar dz1;
        private TextBox p1T;
        private TextBox i1T;
        private TextBox d1T;
        private TextBox d2T;
        private TextBox i2T;
        private TextBox p2T;
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
        private Button stopButton;
        private Button startButton;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private Label label12;
        private TextBox voltageLimitText;
        private TrackBar voltageLimit;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
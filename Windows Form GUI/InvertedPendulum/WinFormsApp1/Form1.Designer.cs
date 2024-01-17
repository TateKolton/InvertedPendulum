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
            label12 = new Label();
            voltageLimitText = new TextBox();
            voltageLimit = new TrackBar();
            controls = new GroupBox();
            label13 = new Label();
            plot = new GroupBox();
            groupBox3 = new GroupBox();
            ports = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)d1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)i1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)k1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)d2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)i2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)k2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dz1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)voltageLimit).BeginInit();
            controls.SuspendLayout();
            plot.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // swingUp
            // 
            swingUp.Location = new Point(26, 49);
            swingUp.Margin = new Padding(4, 5, 4, 5);
            swingUp.Name = "swingUp";
            swingUp.Size = new Size(218, 124);
            swingUp.TabIndex = 1;
            swingUp.TabStop = false;
            swingUp.Text = "Swing Up Pendulum";
            swingUp.UseVisualStyleBackColor = true;
            swingUp.Click += button2_Click;
            // 
            // swingDown
            // 
            swingDown.Location = new Point(26, 198);
            swingDown.Margin = new Padding(4, 5, 4, 5);
            swingDown.Name = "swingDown";
            swingDown.Size = new Size(218, 124);
            swingDown.TabIndex = 2;
            swingDown.TabStop = false;
            swingDown.Text = "Swing Down Pendulum";
            swingDown.UseVisualStyleBackColor = true;
            swingDown.Click += button3_Click;
            // 
            // btnConnectDevice
            // 
            btnConnectDevice.Location = new Point(246, 29);
            btnConnectDevice.Margin = new Padding(4, 5, 4, 5);
            btnConnectDevice.Name = "btnConnectDevice";
            btnConnectDevice.Size = new Size(215, 55);
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
            minus_sixty.Location = new Point(26, 372);
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
            plus_sixty.Location = new Point(133, 372);
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
            plotView.Size = new Size(1013, 976);
            plotView.TabIndex = 14;
            plotView.Text = "plotView1";
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // d1
            // 
            d1.Location = new Point(638, 115);
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
            i1.Location = new Point(474, 115);
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
            k1.Location = new Point(323, 115);
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
            d2.Location = new Point(638, 534);
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
            i2.Location = new Point(474, 534);
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
            k2.Location = new Point(323, 534);
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
            dz1.Location = new Point(789, 304);
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
            p1T.Location = new Point(297, 372);
            p1T.Margin = new Padding(4, 5, 4, 5);
            p1T.Name = "p1T";
            p1T.Size = new Size(88, 31);
            p1T.TabIndex = 26;
            // 
            // i1T
            // 
            i1T.Location = new Point(448, 372);
            i1T.Margin = new Padding(4, 5, 4, 5);
            i1T.Name = "i1T";
            i1T.Size = new Size(88, 31);
            i1T.TabIndex = 27;
            // 
            // d1T
            // 
            d1T.Location = new Point(613, 372);
            d1T.Margin = new Padding(4, 5, 4, 5);
            d1T.Name = "d1T";
            d1T.Size = new Size(88, 31);
            d1T.TabIndex = 28;
            // 
            // d2T
            // 
            d2T.Location = new Point(613, 790);
            d2T.Margin = new Padding(4, 5, 4, 5);
            d2T.Name = "d2T";
            d2T.Size = new Size(88, 31);
            d2T.TabIndex = 31;
            // 
            // i2T
            // 
            i2T.Location = new Point(448, 790);
            i2T.Margin = new Padding(4, 5, 4, 5);
            i2T.Name = "i2T";
            i2T.Size = new Size(88, 31);
            i2T.TabIndex = 30;
            // 
            // p2T
            // 
            p2T.Location = new Point(297, 790);
            p2T.Margin = new Padding(4, 5, 4, 5);
            p2T.Name = "p2T";
            p2T.Size = new Size(88, 31);
            p2T.TabIndex = 29;
            // 
            // dz1T
            // 
            dz1T.Location = new Point(760, 564);
            dz1T.Margin = new Padding(4, 5, 4, 5);
            dz1T.Name = "dz1T";
            dz1T.Size = new Size(91, 31);
            dz1T.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(332, 85);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(22, 25);
            label2.TabIndex = 34;
            label2.Text = "P";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(332, 504);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(22, 25);
            label3.TabIndex = 35;
            label3.Text = "P";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(483, 504);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(17, 25);
            label4.TabIndex = 36;
            label4.Text = "I";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(483, 85);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(17, 25);
            label5.TabIndex = 37;
            label5.Text = "I";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(647, 85);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(25, 25);
            label6.TabIndex = 38;
            label6.Text = "D";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(647, 504);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(25, 25);
            label7.TabIndex = 39;
            label7.Text = "D";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(426, 45);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(123, 32);
            label8.TabIndex = 40;
            label8.Text = "Pendulum";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(451, 457);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(82, 32);
            label9.TabIndex = 41;
            label9.Text = "Motor";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(743, 259);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(123, 32);
            label10.TabIndex = 42;
            label10.Text = "Deadzone";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(825, 32);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(520, 44);
            label11.TabIndex = 43;
            label11.Text = "Rotational Inverted Pendulum";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(890, 260);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(157, 32);
            label12.TabIndex = 49;
            label12.Text = "Voltage Limit";
            // 
            // voltageLimitText
            // 
            voltageLimitText.Location = new Point(934, 566);
            voltageLimitText.Margin = new Padding(4, 5, 4, 5);
            voltageLimitText.Name = "voltageLimitText";
            voltageLimitText.Size = new Size(91, 31);
            voltageLimitText.TabIndex = 48;
            // 
            // voltageLimit
            // 
            voltageLimit.Location = new Point(956, 302);
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
            // controls
            // 
            controls.Controls.Add(label13);
            controls.Controls.Add(d1);
            controls.Controls.Add(label12);
            controls.Controls.Add(label7);
            controls.Controls.Add(plus_sixty);
            controls.Controls.Add(label6);
            controls.Controls.Add(minus_sixty);
            controls.Controls.Add(k1);
            controls.Controls.Add(label5);
            controls.Controls.Add(voltageLimitText);
            controls.Controls.Add(swingDown);
            controls.Controls.Add(swingUp);
            controls.Controls.Add(label4);
            controls.Controls.Add(i1);
            controls.Controls.Add(label3);
            controls.Controls.Add(voltageLimit);
            controls.Controls.Add(label2);
            controls.Controls.Add(k2);
            controls.Controls.Add(i2);
            controls.Controls.Add(d2);
            controls.Controls.Add(dz1);
            controls.Controls.Add(label10);
            controls.Controls.Add(p1T);
            controls.Controls.Add(label9);
            controls.Controls.Add(i1T);
            controls.Controls.Add(label8);
            controls.Controls.Add(d1T);
            controls.Controls.Add(p2T);
            controls.Controls.Add(i2T);
            controls.Controls.Add(d2T);
            controls.Controls.Add(dz1T);
            controls.Location = new Point(1101, 207);
            controls.Name = "controls";
            controls.Size = new Size(1091, 924);
            controls.TabIndex = 50;
            controls.TabStop = false;
            controls.Text = "Pendulum Controls";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(32, 339);
            label13.Name = "label13";
            label13.Size = new Size(157, 25);
            label13.TabIndex = 50;
            label13.Text = "Reference Tracking";
            // 
            // plot
            // 
            plot.Controls.Add(plotView);
            plot.Location = new Point(12, 83);
            plot.Name = "plot";
            plot.Size = new Size(1070, 1048);
            plot.TabIndex = 51;
            plot.TabStop = false;
            plot.Text = "Real-Time Plot";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnConnectDevice);
            groupBox3.Controls.Add(ports);
            groupBox3.Location = new Point(1101, 83);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(483, 100);
            groupBox3.TabIndex = 52;
            groupBox3.TabStop = false;
            groupBox3.Text = "Device Settings";
            // 
            // ports
            // 
            ports.FormattingEnabled = true;
            ports.Location = new Point(26, 41);
            ports.Name = "ports";
            ports.Size = new Size(196, 33);
            ports.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2205, 1149);
            Controls.Add(groupBox3);
            Controls.Add(plot);
            Controls.Add(controls);
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
            controls.ResumeLayout(false);
            controls.PerformLayout();
            plot.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
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
        private OxyPlot.WindowsForms.PlotView plotView1;
        private Label label12;
        private TextBox voltageLimitText;
        private TrackBar voltageLimit;
        private GroupBox controls;
        private GroupBox plot;
        private GroupBox groupBox3;
        private ComboBox ports;
        private Label label13;
    }
}
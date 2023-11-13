% Script to Simulate the performance of an inverted pendulum
% Author: Tate Kolton
% Date Created: May 15, 2023

% System Parameters
Ja = 3e-3;
Kt = 0.55;
Km = 0.1;
La = 0.105;
Lp = 0.06;
Lp_total = 0.12;
Ra = 3;
m = 0.15;
Jp = 1/12*m*Lp_total^2+0.005^2*0.02/4;
g = 9.81;

arm_lim = 165;

T = 1/(sqrt(g/Lp_total)/(2*pi)); % Hz

% State Space Model

% For hanging (stable) position


A1 = [0 0 1 0;
     0 0 0 1;
     0 (m^2*g*Lp^2*La)/(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2) (-Kt*Km*(Jp+m*Lp^2))/(Ra*(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2)) 0;
     0 (-m*g*Lp*(Ja+m*La^2))/(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2) (Kt*Km*m*Lp*La)/(Ra*(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2)) 0
     ];

B1 = [0;
     0;
     (Kt*(Jp+m*Lp^2))/(Ra*(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2));
     (-Kt*m*La*Lp)/(Ra*(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2))
     ];

C2 = [180/pi 0 0 0; 0 180/pi 0 0; 0 0 0 1];

C1 = [180/pi 0 0 0; 0 180/pi 0 0];

D1 = [0;0];

D2 = [0;0;0];

sys_stable = ss(A1, B1, C1, D1);
% 
% figure(1)
% step(sys_stable)
% xlim([0 5]);

% For inverted (un-stable) position


A = [0 0 1 0;
     0 0 0 1;
     0 (m^2*g*Lp^2*La)/(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2) (-Kt*Km*(Jp+m*Lp^2))/(Ra*(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2)) 0;
     0 (m*g*Lp*(Ja+m*La^2))/(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2) (-Kt*Km*m*Lp*La)/(Ra*(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2)) 0
     ];

B = [0;
     0;
     (Kt*(Jp+m*Lp^2))/(Ra*(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2));
     (Kt*m*La*Lp)/(Ra*(Jp*Ja+Jp*m*La^2+Ja*m*Lp^2))
     ];

C = [180/pi 0 0 0; 0 180/pi 0 0];

D = [0;0];

sys_unstable = ss(A, B, C, D);

% figure(2)
% step(sys_unstable)
% xlim([0 0.2]);

% Simulation Step Resposne

figure(2)
plot(out.alpha.Time, out.alpha.Data);
grid on
hold on
plot(out.theta.Time, out.theta.Data);
title("Pendulum / Arm Angle vs Time for Initial Conditions (alpha = 0.1 rad, d(alpha)/dt = 0.05 rad/s)");
xlabel("Time (s)");
ylabel("Alpha (degrees)");
xlim([0 10]);
legend('Pendulum Angle', 'Arm Angle');
hold off














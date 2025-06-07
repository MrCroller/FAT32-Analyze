using System.IO;
using System;
using ClustersCopyAndAnalyze.Services.Copy;
using ClustersCopyAndAnalyze;
using ClustersCopyAndAnalyze.Services.Clusters;

namespace CCAA

{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // ApplicationConfiguration.Initialize();

            Form1 view = new();

            Progress<�����������������������> analyzeProgress = new((type) => view.ShowProgress(type.ToString()));
            Progress<double> copyProgress = new(view.ShowProgress);

            ThreadStarter starter = new(analyzeProgress, copyProgress);
            // ����������� ����� �� ���������� �������� �� ������� ������
            view.OnTryStart += starter.TryStartOperation;

            // ��������� ���� ����������
            Application.Run(view);
        }
    }
}
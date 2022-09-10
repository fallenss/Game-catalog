using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Курсилио
{
    /// <summary>
    /// Логика взаимодействия для report.xaml
    /// </summary>
    public partial class report : Window
    {
        public report()
        {
            InitializeComponent();
            DataContext = new PersonViewModel(this);

        }
        public class PersonViewModel
        {

            private report window;
            private ReportViewer reportviewer;
            public PersonViewModel(report _window)
            {
                window = _window;
                this.reportviewer = window._reportviewer;
                Initialize();
            }

            private void Initialize()
            {
                reportviewer.LocalReport.DataSources.Clear();
                var rpds_model = new ReportDataSource() { Name = "DataSet1", Value = Каталог_видеоигрEntities2.GetContext().Пользователи.ToList() };
                reportviewer.LocalReport.DataSources.Add(rpds_model);
                reportviewer.LocalReport.EnableExternalImages = true;
                reportviewer.LocalReport.ReportPath = ContentStart;
                reportviewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportviewer.Refresh(); 
                reportviewer.RefreshReport();
            }
            private static string _path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            public static string ContentStart = _path + @"\Курсилио\Report1.rdlc";
        }

        private void ff_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}

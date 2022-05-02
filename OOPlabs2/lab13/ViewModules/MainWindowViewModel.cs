using lab13.Commands;
using lab13.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab13.ViewModules
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Title
        private string _Title = "Doctors lab13";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion
        private ObservableCollection<Ticket> _Tickets = new ObservableCollection<Ticket>();
        public ObservableCollection<Ticket> Tickets
        {
            get => _Tickets;
            set => Set(ref _Tickets, value);
        }
        private ObservableCollection<Doctor> _Doctors = new ObservableCollection<Doctor>();
        public ObservableCollection<Doctor> Doctors
        {
            get => _Doctors;
            set => Set(ref _Doctors, value);
        }
        public ICommand IssueTicketCommand { get; }
        private void OnIssueTicketCommandExecuted(object par)
        {
            var name = par as string;
            using (DoctorsDbContext dbContext = new DoctorsDbContext())
            {
                var doctor = dbContext.Doctors.Single(o => o.Name == name);
                var lastTicket = Tickets.LastOrDefault();
                int number = 1;
                if (lastTicket != null) number = lastTicket.Number + 1;
                var ticket = new Ticket()
                {
                    Doctor = doctor,
                    Number = number,
                    Time = DateTime.Now,
                    DoctorID = doctor.ID
                };
                dbContext.Tickets.Add(ticket);
                dbContext.SaveChanges();
                UpdateCollections();
            }
        }
        public ICommand CancelTicketCommand { get; }
        private void OnCancelTicketCommandExecuted(object par)
        {
            var number = Convert.ToInt32(par as string);
            //var ticket = Tickets.First(x => x.Number == number);
            using (DoctorsDbContext dbContext = new DoctorsDbContext())
            {
                var ticket = dbContext.Tickets.Single(o => o.Number == number);
                if (ticket != null)
                {
                    dbContext.Tickets.Remove(ticket);
                    dbContext.SaveChanges();
                    UpdateCollections();
                }
            }
        }
        private bool CanCancelTicketCommandExecute(object par) => Tickets.Count > 0;
        public void UpdateCollections()
        {
            Doctors.Clear();
            Tickets.Clear();
            using (DoctorsDbContext dbContext = new DoctorsDbContext())
            {
                foreach (var item in dbContext.Doctors)
                {
                    Doctors.Add(item);
                }
                foreach (var item in dbContext.Tickets)
                {
                    Tickets.Add(item);
                }
            }
        }
        public MainWindowViewModel()
        {
            IssueTicketCommand = new LambdaCommand(OnIssueTicketCommandExecuted);
            CancelTicketCommand = new LambdaCommand(OnCancelTicketCommandExecuted, CanCancelTicketCommandExecute);
            using (DoctorsDbContext dbContext = new DoctorsDbContext())
            {
                //dbContext.Doctors.Add(new Doctor() { Name = "Vita", Categories = "First", Department = "x", Speciality = "Therapist" });
                //dbContext.Doctors.Add(new Doctor() { Name = "Gena", Categories = "Second", Department = "x", Speciality = "Therapist" });
                //dbContext.Doctors.Add(new Doctor() { Name = "Olga", Categories = "Second", Department = "x2", Speciality = "Therapist" });
                //dbContext.SaveChanges();
                foreach (var item in dbContext.Doctors)
                {
                    Doctors.Add(item);
                }
                foreach (var item in dbContext.Tickets)
                {
                    Tickets.Add(item);
                }
            }
        }
    }
}
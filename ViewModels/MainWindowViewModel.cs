using System;
using System.Reactive;
using ReactiveUI;

namespace DateApp.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private string _dateInput = string.Empty; 
        private string _currentDate = string.Empty;  
        private string _daysToAdd = string.Empty; 
        private string _monthsToAdd = string.Empty;  
        private string _yearsToAdd = string.Empty;  
        private Date? _date; 

        public string DateInput
        {
            get => _dateInput;
            set => this.RaiseAndSetIfChanged(ref _dateInput, value);
        }

        public string CurrentDate
        {
            get => _currentDate;
            set => this.RaiseAndSetIfChanged(ref _currentDate, value);
        }

        public string DaysToAdd
        {
            get => _daysToAdd;
            set => this.RaiseAndSetIfChanged(ref _daysToAdd, value);
        }

        public string MonthsToAdd
        {
            get => _monthsToAdd;
            set => this.RaiseAndSetIfChanged(ref _monthsToAdd, value);
        }

        public string YearsToAdd
        {
            get => _yearsToAdd;
            set => this.RaiseAndSetIfChanged(ref _yearsToAdd, value);
        }

        public ReactiveCommand<Unit, Unit> SetDateCommand { get; }
        public ReactiveCommand<Unit, Unit> AddDaysCommand { get; }
        public ReactiveCommand<Unit, Unit> AddMonthsCommand { get; }
        public ReactiveCommand<Unit, Unit> AddYearsCommand { get; }

        public MainWindowViewModel()
        {
            SetDateCommand = ReactiveCommand.Create(SetDate);
            AddDaysCommand = ReactiveCommand.Create(AddDays);
            AddMonthsCommand = ReactiveCommand.Create(AddMonths);
            AddYearsCommand = ReactiveCommand.Create(AddYears);
        }

        private void SetDate()
        {
            try
            {
                var parts = DateInput.Split('.');
                if (parts.Length != 3)
                    throw new FormatException("Неверный формат даты.");

                int day = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int year = int.Parse(parts[2]);

                _date = new Date(year, month, day);
                if (!_date.IsValidDate())
                    throw new ArgumentException("Неверная дата.");

                CurrentDate = _date.ToString();
            }
            catch (Exception ex)
            {
                CurrentDate = $"Ошибка: {ex.Message}";
            }
        }

        private void AddDays()
        {
            if (_date == null) return;
            try
            {
                if (int.TryParse(DaysToAdd, out int days))
                {
                    _date.AddDays(days);
                    CurrentDate = _date.ToString();
                }
            }
            catch (Exception ex)
            {
                CurrentDate = $"Ошибка: {ex.Message}";
            }
        }

        private void AddMonths()
        {
            if (_date == null) return;
            try
            {
                if (int.TryParse(MonthsToAdd, out int months))
                {
                    _date.AddMonths(months);
                    CurrentDate = _date.ToString();
                }
            }
            catch (Exception ex)
            {
                CurrentDate = $"Ошибка: {ex.Message}";
            }
        }

        private void AddYears()
        {
            if (_date == null) return;
            try
            {
                if (int.TryParse(YearsToAdd, out int years))
                {
                    _date.AddYears(years);
                    CurrentDate = _date.ToString();
                }
            }
            catch (Exception ex)
            {
                CurrentDate = $"Ошибка: {ex.Message}";
            }
        }
    }
}
namespace Timer.Data
{
    public class TimerService
    {
        private int _hours = 0;
        private int _minutes = 0;
        private int _seconds = 0;
        public bool IsStarted { get; private set; }

        public int GetHours()
        {
            return _hours;
        }

        public int GetMinutes()
        {
            return _minutes;
        }

        public int GetSeconds()
        {
            return _seconds;
        }

        public async Task StartTimer(string hours, string minutes, string seconds)
        {
            if(int.TryParse(hours, out _hours) && int.TryParse(minutes, out _minutes) 
                && int.TryParse(seconds, out _seconds) && !IsStarted)
            {
                IsStarted = true;
                while(IsStarted)
                {
                    await Task.Delay(1000);
                    if(_seconds > 0)
                    {
                        _seconds--;
                    }
                    else if(_minutes > 0)
                    {
                        _minutes--;
                        _seconds = 59;
                    }
                    else if(_hours > 0)
                    {
                        _hours--;
                        _minutes = 59;
                        _seconds = 59;
                    }
                    else
                    {
                        IsStarted = false;
                    }
                }
            }
        }

        public void FinishTimer()
        {
            _hours = 0;
            _minutes = 0;
            _seconds = 0;
            IsStarted = false;
        }

        public void PlusMinute()
        {
            _minutes++;
            if(_minutes == 60)
            {
                _hours++;
                _minutes = 0;
            }
        }
    }
}

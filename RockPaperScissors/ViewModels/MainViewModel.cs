using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RockPaperScissors.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int _chosenValue = -1;
        private string _textResult = string.Empty;
        private int _pick = 0;

        //For NOW ROCK == 1 ; Paper == 2 ; SCISSORS == 3

        public MainViewModel()
        {
            RockCommand = new Command(() =>
            {
                ChosenValue = 1;
                TextResult = GameResolver();
            });

            PaperCommand = new Command(() =>
            {
                ChosenValue = 2;
                TextResult = GameResolver();
            });

            ScissorsCommand = new Command(() =>
            {
                ChosenValue = 3;
                TextResult = GameResolver();
            });
        }

        public int ChosenValue
        {
            get { return _chosenValue; }
            set
            {
                _chosenValue = value;
                OnPropertyChanged();
                (RockCommand as Command).ChangeCanExecute();
                (PaperCommand as Command).ChangeCanExecute();
                (ScissorsCommand as Command).ChangeCanExecute();
            }
        }

        public string TextResult
        {
            get { return _textResult; }
            set
            {
                _textResult = value;
                OnPropertyChanged();
            }
        }

        public int Pick
        {
            get { return _pick; }
            set
            {
                _pick = value;
                OnPropertyChanged();
            }
        }

        public ICommand RockCommand { get; private set; }
        public ICommand PaperCommand { get; private set; }
        public ICommand ScissorsCommand { get; private set; }


        public string GameResolver()
        {
            var random = new Random();
            Pick = random.Next(1, 4);

            if (Pick == ChosenValue)
            {
                return "It is a tie";
            }
            else if ((Pick == 1 && ChosenValue == 3) || (Pick == 2 && ChosenValue == 1) || (Pick == 3 && ChosenValue == 2))
            {
                return "You lost";
            }
            else
            {
                return "You won";
            }
        }

        #region MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}

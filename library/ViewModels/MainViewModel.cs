using library.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace library.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private List<BaseViewModel> _viewModels = new List<BaseViewModel>();
        private BaseViewModel _currentViewModel;
        private int _mode = 0;

        private ICommand _changeViewModelCommand;

        public MainViewModel()
        {
            _viewModels.Add(new BookSearchViewModel());

            CurrentViewModel = _viewModels[0];
        }

        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }

            set
            {
                _currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        private void ChangeViewModel(BaseViewModel viewModel)
        {
            if (!_viewModels.Contains(viewModel))
            {
                _viewModels.Add(viewModel);
            }

            CurrentViewModel = _viewModels.Find(vm => vm == viewModel);
        }

        public ICommand ChangeViewModelCommand
        {
            get
            {
                if (_changeViewModelCommand == null)
                {
                    //_changeViewModelCommand = new RelayCommand(new Action<object>(Export),
                    //    param => IsNotListEmpty);
                }

                return _changeViewModelCommand;
            }
        }

        public int Mode
        {
            get {
                return _mode;
            }

            set {
                _mode = value;
                OnPropertyChanged("Mode");
            }
        }
    }
}

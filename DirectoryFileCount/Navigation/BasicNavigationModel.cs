using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryFileCount.Navigation
{
    internal abstract class BasicNavigationModel : INavigationModel
    {
        private readonly IContentOwner _contentOwner;
        private readonly Dictionary<ViewType, INavigatable> _viewsDictionary;

        protected BasicNavigationModel(IContentOwner contentOwner)
        {
            _contentOwner = contentOwner;
            _viewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        protected IContentOwner ContentOwner
        {
            get { return _contentOwner; }
        }

        protected Dictionary<ViewType, INavigatable> ViewsDictionary
        {
            get { return _viewsDictionary; }
        }

        public void Navigate(ViewType viewType)
        {
            if (viewType == ViewType.History)
            {
                ContentOwner.ContentControl.Content = new UserRequestsHistoryView();
            }
            else
            {
                if (!ViewsDictionary.ContainsKey(viewType))
                    InitializeView(viewType);
                ContentOwner.ContentControl.Content = ViewsDictionary[viewType];
            }
        }

        protected abstract void InitializeView(ViewType viewType);

    }
}

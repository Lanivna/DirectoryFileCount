using System.Windows.Controls;

namespace DirectoryFileCount.Navigation
{
    internal interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}

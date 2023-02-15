// --------------------------------------------------------------------------------------------------------------------
// <copyright http://www.opensource.org file="Row.cs">
//    (c) 2023. See license.txt in binary folder.
// </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace AsciiDocNet
{
    public class Row
    {
        #region Fields

        private string[] _columns;

        #endregion

        #region Constructors and Destructors

        public Row(params string[] columns)
        {
            _columns = columns;
        }

        #endregion
    }
}
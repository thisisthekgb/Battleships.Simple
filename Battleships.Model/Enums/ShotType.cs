using System.ComponentModel;

namespace Battleships.Model.Enums
{
    /// <summary>
    /// Differing types of shot that can happen 
    /// </summary>
    public enum ShotType
    {
        [Description("M")]
        Miss,
        [Description("H")]
        Hit,
        [Description("S")]
        Sunk,
        [Description(".")]
        Unknown,
        [Description("Youve already shot there !")]
        Existing
    }
}

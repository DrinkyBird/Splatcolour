using System.Windows.Forms;

namespace SplatColour
{
    public enum InkGroup
    {
        Uncategorised,
        Singleplayer,
        Regular,
        Ranked,

        NumGroups
    }

    public struct InkFile
    {
        public static readonly string[] InkGroupNames =
        {
            "Uncategorised",
            "Octo Valley",
            "Regular Battle",
            "Ranked Battle"
        };

        public static readonly InkFile[] Files =
        {
            new InkFile("GfxSetting_Tut_Enemy.params", "Tutorial", InkGroup.Uncategorised),
            new InkFile("GfxSetting_Vss_Option_BlueOrange.params", "Colour Lock (multiplayer)", InkGroup.Uncategorised),
            new InkFile("GfxSetting_Msn_Option_Yellow.params", "Colour Lock (Octo Valley)", InkGroup.Uncategorised),

            new InkFile("GfxSetting_Msn_DarkBlue.params", "DarkBlue", InkGroup.Singleplayer),
            new InkFile("GfxSetting_Msn_Green_Default.params", "Green_Default", InkGroup.Singleplayer),
            new InkFile("GfxSetting_Msn_Lilac.params", "Lilac", InkGroup.Singleplayer),
            new InkFile("GfxSetting_Msn_LumiGreen.params", "LumiGreen", InkGroup.Singleplayer),
            new InkFile("GfxSetting_Msn_Marigold.params", "Marigold", InkGroup.Singleplayer),
            new InkFile("GfxSetting_Msn_MothGreen.params", "MothGreen", InkGroup.Singleplayer),
            new InkFile("GfxSetting_Msn_NightLumiGreen.params", "NightLumiGreen", InkGroup.Singleplayer),
            new InkFile("GfxSetting_Msn_NightMarigold.params", "NightMarigold", InkGroup.Singleplayer),
            new InkFile("GfxSetting_Msn_Orange.params", "Orange", InkGroup.Singleplayer),
            new InkFile("GfxSetting_Msn_Soda.params", "Soda", InkGroup.Singleplayer),
            new InkFile("GfxSetting_Msn_Turquoise.params", "Turquoise", InkGroup.Singleplayer),
            new InkFile("GfxSetting_Msn_Yellow.params", "Yellow", InkGroup.Singleplayer),

            new InkFile("GfxSetting_Vss_Gachi_DarkblueYellow.params", "DarkblueYellow", InkGroup.Ranked),
            new InkFile("GfxSetting_Vss_Gachi_GreenMazenta.params", "GreenMazenta", InkGroup.Ranked),
            new InkFile("GfxSetting_Vss_Gachi_GreenOrange.params", "GreenOrange", InkGroup.Ranked),
            new InkFile("GfxSetting_Vss_Gachi_LightgreenBlue.params", "LightgreenBlue", InkGroup.Ranked),
            new InkFile("GfxSetting_Vss_Gachi_LumigreenPurple.params", "LumigreenPurple", InkGroup.Ranked),
            new InkFile("GfxSetting_Vss_Gachi_SodaPink.params", "SodaPink", InkGroup.Ranked),
            new InkFile("GfxSetting_Vss_Gachi_YellowLilac_Default.params", "YellowLilac_Default", InkGroup.Ranked),

            new InkFile("GfxSetting_Vss_Regular_BlueLime.params", "BlueLime", InkGroup.Regular),
            new InkFile("GfxSetting_Vss_Regular_GreenPurple.params", "GreenPurple", InkGroup.Regular),
            new InkFile("GfxSetting_Vss_Regular_LightBlueDarkBlue.params", "LightBlueDarkBlue", InkGroup.Regular),
            new InkFile("GfxSetting_Vss_Regular_LightBlueYellow.params", "LightBlueYellow (unused)", InkGroup.Regular),
            new InkFile("GfxSetting_Vss_Regular_OrangeBlue_Default.params", "OrangeBlue_Default", InkGroup.Regular),
            new InkFile("GfxSetting_Vss_Regular_PinkBlue.params", "PinkBlue", InkGroup.Regular),
            new InkFile("GfxSetting_Vss_Regular_PinkGreen.params", "PinkGreen", InkGroup.Regular),
            new InkFile("GfxSetting_Vss_Regular_PinkOrange.params", "PinkOrange", InkGroup.Regular),
            new InkFile("GfxSetting_Vss_Regular_TurquoiseOrange.params", "TurquoiseOrange", InkGroup.Regular),
        };

        public string FileName { get; }
        public string Name { get; }
        public InkGroup Group { get; }

        public InkFile(string fileName, string name, InkGroup group)
        {
            this.FileName = fileName;
            this.Name = name;
            this.Group = group;
        }
    }

    public class InkFileListItem : ListViewItem
    {
        public InkFile File { get; }

        public InkFileListItem(InkFile file) : base(file.Name)
        {
            this.File = file;
        }
    }
}

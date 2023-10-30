//Written for Astro Sentai Jarbonder. https://store.steampowered.com/app/1487320/Astro_Sentai_Jarbonder/
using System.Text;

class Astro_Sentai_Jarbonder_Extractor
{
    public static BinaryReader br;
    public static BinaryWriter bw;
    public static void Main(string[] args)
    {
        br = new(File.OpenRead(args[0]));
        if (new string(br.ReadChars(4)) != "MLOV")
        {
            throw new ArgumentException("This is not Astro Sentai Jarbonder's GAME.DAT file.");
        }
        br.ReadInt32();
        int nBlockA = br.ReadInt32();
        br.ReadInt32();
        List<BLOCK_A> blockA = new List<BLOCK_A>();

        for (int i = 0; i < nBlockA; i++)
        {
            blockA.Add(new());
        }

        for (int i = 0; i < nBlockA; i++)
        {
            br.BaseStream.Position = blockA[i].offset;
            byte[] magicBytes = br.ReadBytes(4);
            string magic = new string(Encoding.UTF7.GetString(magicBytes));
            string type = "";
            switch (magic)
            {
                case "OggS":
                    type = ".ogg";
                    break;
                case "\u0089PNG":
                    type = ".png";
                    break;
                case "RIFF":
                    type = ".wav";
                    break;
            }
            bw = new(File.Create(Path.GetDirectoryName(args[0]) + "//" + i + type));
            bw.Write(magicBytes);
            bw.Write(br.ReadBytes(blockA[i].size - 4));
            bw.Close();
        }
    }

    class BLOCK_A
    {
        int intA = br.ReadInt32();
        public int size = br.ReadInt32();
        int intC = br.ReadInt32();
        public int offset = br.ReadInt32();
        int intE = br.ReadInt32();
        int intF = br.ReadInt32();
        int intG = br.ReadInt32();
        int intH = br.ReadInt32();
        int intI = br.ReadInt32();
        int intJ = br.ReadInt32();
        int intK = br.ReadInt32();
        int intL = br.ReadInt32();
        int intM = br.ReadInt32();
        int intN = br.ReadInt32();
        int intO = br.ReadInt32();
        int intP = br.ReadInt32();
    }
}
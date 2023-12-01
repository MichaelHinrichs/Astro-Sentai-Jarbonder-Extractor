//Written for Astro Sentai Jarbonder. https://store.steampowered.com/app/1487320/Astro_Sentai_Jarbonder/

class Astro_Sentai_Jarbonder_Extractor
{
    static BinaryReader br;
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
            WriteFile(blockA[i], args[0], i);
        }
    }

    static void WriteFile(BLOCK_A blockA , string file, int i)
    {
        br.BaseStream.Position = blockA.offset;
        BinaryWriter bw = new(File.Create(Path.GetDirectoryName(file) + "//" + i + GetType()));
        br.BaseStream.Position -= 4;
        bw.Write(br.ReadBytes(blockA.size));
        bw.Close();
    }

    static new string GetType()
    {
        byte[] magicBytes = br.ReadBytes(4);
        string magic = new string(System.Text.Encoding.UTF7.GetString(magicBytes));
        switch (magic)
        {
            case "OggS":
                return ".ogg";
            case "\u0089PNG":
                return ".png";
            case "RIFF":
                return ".wav";
            default: throw new Exception("Unrecognized subfile type.");
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

namespace Commandos.Model.Characters.Commandos
{
    public class GreenBeret : Commando
    {
        public override string Name => "Green Beret";

        public override string SecondaryType => "ACOM";

        public override string TokenId => "COMANDO";

        public override string AnimationFileName => "COMANDO";
    }

    public class Sniper : Commando
    {
        public override string Name => "Sniper";

        public override string SecondaryType => "AFRN";

        public override string TokenId => "FRANCOTIRADOR";

        public override string AnimationFileName => "FRANCOT";
    }

    public class Marine : Commando
    {
        public override string Name => "Marine";

        public override string SecondaryType => "ALAN";

        public override string TokenId => "LANCHERO";

        public override string AnimationFileName => "LANCHERO";
    }

    public class Sapper : Commando
    {
        public override string Name => "Sapper";

        public override string SecondaryType => "AART";

        public override string TokenId => "ARTIFICIERO";

        public override string AnimationFileName => "ARTIFIC";
    }

    public class Driver : Commando
    {
        public override string Name => "Driver";

        public override string SecondaryType => "ACON";

        public override string TokenId => "CONDUCTOR";

        public override string AnimationFileName => "CONDUCD";
    }

    public class Spy : Commando
    {
        public override string Name => "Spy";

        public override string SecondaryType => "AESP";

        public override string TokenId => "ESPIA";

        public override string AnimationFileName => "ESPIA";
    }

    public class Natasha : Commando
    {
        public override string Name => "Natasha";

        public override string SecondaryType => "ANAT";

        public override string TokenId => "NATACHA";

        public override string AnimationFileName => "NATASHA";
    }

    public class Thief : Commando
    {
        public override string Name => "Thief";

        public override string SecondaryType => "ARAT";

        public override string TokenId => "RATERO";

        public override string AnimationFileName => "RATERO";
    }

    //public class Whisky : Commando
    //{
    //    public override string TokenId => "COMANDO";
    //}

    //public class Wilson : Commando
    //{
    //    public override string TokenId => "COMANDO";
    //}
}

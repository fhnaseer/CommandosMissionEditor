namespace Commandos.Model.Characters.Commandos
{
    public class Commando : Character
    {
        public virtual string Name { get; }

        public virtual string SecondaryType { get; }

        public virtual string AnimationFileName { get; }

        public virtual string AnimationFileNameComplete => $"{AnimationFileName}.ANI";

        public override string ToString() => Name;
    }
}

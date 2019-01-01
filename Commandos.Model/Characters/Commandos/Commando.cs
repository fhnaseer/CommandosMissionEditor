namespace Commandos.Model.Characters.Commandos
{
    public class Commando : Character
    {
        public virtual string Name { get; }

        public virtual string SecondaryType { get; }

        private CommandoAbilities _abilities;
        public CommandoAbilities Abilities
        {
            get => _abilities ?? (_abilities = new CommandoAbilities());
            set => _abilities = value;
        }

        public virtual string AnimationFileName { get; }

        public virtual string AnimationFileNameComplete => $"{AnimationFileName}.ANI";

        public override string ToString() => Name;
    }
}

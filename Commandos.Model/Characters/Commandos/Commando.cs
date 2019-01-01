namespace Commandos.Model.Characters.Commandos
{
    public abstract class Commando : Character
    {
        public abstract string Name { get; }

        public abstract string SecondaryType { get; }

        private CommandoAbilities _abilities;
        public CommandoAbilities Abilities
        {
            get => _abilities ?? (_abilities = new CommandoAbilities());
            set => _abilities = value;
        }

        public abstract string AnimationFileName { get; }

        public virtual string AnimationFileNameComplete => $"{AnimationFileName}.ANI";

        public override string ToString() => Name;
    }
}

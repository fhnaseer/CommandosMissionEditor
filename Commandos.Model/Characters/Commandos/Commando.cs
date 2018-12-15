namespace Commandos.Model.Characters.Commandos
{
    public abstract class Commando
    {
        private CommandoAbilities _abilities;
        public CommandoAbilities Abilities
        {
            get => _abilities ?? (_abilities = new CommandoAbilities());
            set => _abilities = value;
        }
    }
}

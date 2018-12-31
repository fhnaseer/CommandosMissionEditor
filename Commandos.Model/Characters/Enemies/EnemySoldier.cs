namespace Commandos.Model.Characters.Enemies
{
    public abstract class EnemySoldier : EnemyCharacter
    {
        private string _tokenId;
        public override string TokenId
        {
            get => _tokenId ?? (_tokenId = AnimationFileName);
            set => _tokenId = value;
        }

        public abstract string Name { get; }

        public abstract string Range { get; }

        public abstract string Trigger { get; }

        public abstract string AnimationFileName { get; }

        public virtual string AnimationFileNameComplete => $"{AnimationFileName}.ANI";

        public override string ToString() => $"{Name} {TokenId} {Position?.ToString()}";
    }
}

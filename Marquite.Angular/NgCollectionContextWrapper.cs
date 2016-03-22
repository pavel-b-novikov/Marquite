namespace Marquite.Angular
{
    public class NgCollectionContextWrapper<TModel, TParent>
    {
        [OverrideName("$index")]
        public int Index { get; set; }

        [OverrideName("$first")]
        public bool First { get; set; }

        [OverrideName("$last")]
        public bool Last { get; set; }

        [OverrideName("$middle")]
        public bool Middle { get; set; }

        [OverrideName("$even")]
        public bool Even { get; set; }

        [OverrideName("$odd")]
        public bool Odd { get; set; }

        [OverrideName("$parent")]
        public TParent Parent { get; set; }

        [IsModel]
        public TModel Model { get; set; }
    }
}
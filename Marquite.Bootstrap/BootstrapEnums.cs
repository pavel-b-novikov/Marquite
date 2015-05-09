using Marquite.Core;

namespace Marquite.Bootstrap
{
    [LookupEnum]
    public enum BootstrapPull
    {
        [LookupString("pull-left")] Left,
        [LookupString("pull-right")] Right
    }

    [LookupEnum]
    public enum Hiding
    {
        [LookupString("show")] Show,
        [LookupString("hidden")] Hidden
    }

    [LookupEnum]
    public enum Background
    {
        [LookupString("bg-primary")] Primary,
        [LookupString("bg-success")] Success,
        [LookupString("bg-info")] Info,
        [LookupString("bg-warning")] Warning,
        [LookupString("bg-danger")] Danger
    }


    [LookupEnum]
    public enum TextColor
    {
        [LookupString("bg-primary")] Primary,
        [LookupString("bg-success")] Success,
        [LookupString("bg-info")] Info,
        [LookupString("bg-warning")] Warning,
        [LookupString("bg-danger")] Danger
    }

    [LookupEnum]
    public enum Device
    {
        [LookupString("xs")] ExtraSmall,
        [LookupString("sm")] Small,
        [LookupString("md")] Medium,
        [LookupString("lg")] Large,
        [LookupString("print")] Print
    }

    [LookupEnum]
    public enum Display
    {
        [LookupString("block")] Block,
        [LookupString("inline")] Inline,
        [LookupString("block")] InlineBlock
    }

    [LookupEnum]
    public enum TextCasing
    {
        [LookupString("text-lowercase")] Lowrcase,
        [LookupString("text-uppercase")] Uppercase,
        [LookupString("text-capitalize")] Capitalize
    }

    [LookupEnum]
    public enum ListStyles
    {
        [LookupString("list-unstyled")] Unstyled,
        [LookupString("list-inline")] Inline
    }

    [LookupEnum]
    public enum Color
    {
        [LookupString("active")] Active,
        [LookupString("primary")] Primary,
        [LookupString("success")] Success,
        [LookupString("info")] Info,
        [LookupString("warning")] Warning,
        [LookupString("danger")] Danger
    }

    [LookupEnum]
    public enum TableClasses
    {
        [LookupString("table-striped")] Striped,
        [LookupString("table-bordered")] Bordered,
        [LookupString("table-hover")] HoverRows,
        [LookupString("table-condensed")] Condensed
    }

    [LookupEnum]
    public enum ButtonColor
    {
        [LookupString("btn-default")] Default,
        [LookupString("btn-primary")] Primary,
        [LookupString("btn-success")] Success,
        [LookupString("btn-info")] Info,
        [LookupString("btn-warning")] Warning,
        [LookupString("btn-danger")] Danger
    }

    [LookupEnum]
    public enum ButtonSize
    {
        [LookupString("btn-xs")] XtraSmall,
        [LookupString("btn-sm")] Small,
        [LookupString("")] Default,
        [LookupString("btn-lg")] Large
    }

    [LookupEnum]
    public enum TextAlign
    {
        [LookupString("text-left")] Left,
        [LookupString("text-center")] Center,
        [LookupString("text-right")] Right,
        [LookupString("text-justify")] Justify
    }

    [LookupEnum]
    public enum ImageStyle
    {
        [LookupString("img-rounded")] Rounded,
        [LookupString("img-circle")] Circle,
        [LookupString("img-thumbnail")] Thumbnail
    }

    [LookupEnum]
    public enum InputType
    {
        [LookupString("text")] Text,
        [LookupString("password")] Password,
        [LookupString("radio")] Radio,
        [LookupString("checkbox")] Checkbox,
        [LookupString("button")] Button,
        [LookupString("color")] Color,
        [LookupString("date")] Date,
        [LookupString("datetime")] Datetime,
        [LookupString("datetime-local")] DatetimeLocal,
        [LookupString("email")] Email,
        [LookupString("month")] Month,
        [LookupString("number")] Number,
        [LookupString("range")] Range,
        [LookupString("search")] Search,
        [LookupString("tel")] Tel,
        [LookupString("time")] Time,
        [LookupString("url")] Url,
        [LookupString("week")] Week
    }

    [LookupEnum]
    public enum GlyphIcon
    {
        [LookupString("glyphicon glyphicon-asterisk")] Asterisk,
        [LookupString("glyphicon glyphicon-plus")] Plus,
        [LookupString("glyphicon glyphicon-euro")] Euro,
        [LookupString("glyphicon glyphicon-eur")] Eur,
        [LookupString("glyphicon glyphicon-minus")] Minus,
        [LookupString("glyphicon glyphicon-cloud")] Cloud,
        [LookupString("glyphicon glyphicon-envelope")] Envelope,
        [LookupString("glyphicon glyphicon-pencil")] Pencil,
        [LookupString("glyphicon glyphicon-glass")] Glass,
        [LookupString("glyphicon glyphicon-music")] Music,
        [LookupString("glyphicon glyphicon-search")] Search,
        [LookupString("glyphicon glyphicon-heart")] Heart,
        [LookupString("glyphicon glyphicon-star")] Star,
        [LookupString("glyphicon glyphicon-star-empty")] StarEmpty,
        [LookupString("glyphicon glyphicon-user")] User,
        [LookupString("glyphicon glyphicon-film")] Film,
        [LookupString("glyphicon glyphicon-th-large")] ThLarge,
        [LookupString("glyphicon glyphicon-th")] Th,
        [LookupString("glyphicon glyphicon-th-list")] ThList,
        [LookupString("glyphicon glyphicon-ok")] Ok,
        [LookupString("glyphicon glyphicon-remove")] Remove,
        [LookupString("glyphicon glyphicon-zoom-in")] ZoomIn,
        [LookupString("glyphicon glyphicon-zoom-out")] ZoomOut,
        [LookupString("glyphicon glyphicon-off")] Off,
        [LookupString("glyphicon glyphicon-signal")] Signal,
        [LookupString("glyphicon glyphicon-cog")] Cog,
        [LookupString("glyphicon glyphicon-trash")] Trash,
        [LookupString("glyphicon glyphicon-home")] Home,
        [LookupString("glyphicon glyphicon-file")] File,
        [LookupString("glyphicon glyphicon-time")] Time,
        [LookupString("glyphicon glyphicon-road")] Road,
        [LookupString("glyphicon glyphicon-download-alt")] DownloadAlt,
        [LookupString("glyphicon glyphicon-download")] Download,
        [LookupString("glyphicon glyphicon-upload")] Upload,
        [LookupString("glyphicon glyphicon-inbox")] Inbox,
        [LookupString("glyphicon glyphicon-play-circle")] PlayCircle,
        [LookupString("glyphicon glyphicon-repeat")] Repeat,
        [LookupString("glyphicon glyphicon-refresh")] Refresh,
        [LookupString("glyphicon glyphicon-list-alt")] ListAlt,
        [LookupString("glyphicon glyphicon-lock")] Lock,
        [LookupString("glyphicon glyphicon-flag")] Flag,
        [LookupString("glyphicon glyphicon-headphones")] Headphones,
        [LookupString("glyphicon glyphicon-volume-off")] VolumeOff,
        [LookupString("glyphicon glyphicon-volume-down")] VolumeDown,
        [LookupString("glyphicon glyphicon-volume-up")] VolumeUp,
        [LookupString("glyphicon glyphicon-qrcode")] Qrcode,
        [LookupString("glyphicon glyphicon-barcode")] Barcode,
        [LookupString("glyphicon glyphicon-tag")] Tag,
        [LookupString("glyphicon glyphicon-tags")] Tags,
        [LookupString("glyphicon glyphicon-book")] Book,
        [LookupString("glyphicon glyphicon-bookmark")] Bookmark,
        [LookupString("glyphicon glyphicon-print")] Print,
        [LookupString("glyphicon glyphicon-camera")] Camera,
        [LookupString("glyphicon glyphicon-font")] Font,
        [LookupString("glyphicon glyphicon-bold")] Bold,
        [LookupString("glyphicon glyphicon-italic")] Italic,
        [LookupString("glyphicon glyphicon-text-height")] TextHeight,
        [LookupString("glyphicon glyphicon-text-width")] TextWidth,
        [LookupString("glyphicon glyphicon-align-left")] AlignLeft,
        [LookupString("glyphicon glyphicon-align-center")] AlignCenter,
        [LookupString("glyphicon glyphicon-align-right")] AlignRight,
        [LookupString("glyphicon glyphicon-align-justify")] AlignJustify,
        [LookupString("glyphicon glyphicon-list")] List,
        [LookupString("glyphicon glyphicon-indent-left")] IndentLeft,
        [LookupString("glyphicon glyphicon-indent-right")] IndentRight,
        [LookupString("glyphicon glyphicon-facetime-video")] FacetimeVideo,
        [LookupString("glyphicon glyphicon-picture")] Picture,
        [LookupString("glyphicon glyphicon-map-marker")] MapMarker,
        [LookupString("glyphicon glyphicon-adjust")] Adjust,
        [LookupString("glyphicon glyphicon-tint")] Tint,
        [LookupString("glyphicon glyphicon-edit")] Edit,
        [LookupString("glyphicon glyphicon-share")] Share,
        [LookupString("glyphicon glyphicon-check")] Check,
        [LookupString("glyphicon glyphicon-move")] Move,
        [LookupString("glyphicon glyphicon-step-backward")] StepBackward,
        [LookupString("glyphicon glyphicon-fast-backward")] FastBackward,
        [LookupString("glyphicon glyphicon-backward")] Backward,
        [LookupString("glyphicon glyphicon-play")] Play,
        [LookupString("glyphicon glyphicon-pause")] Pause,
        [LookupString("glyphicon glyphicon-stop")] Stop,
        [LookupString("glyphicon glyphicon-forward")] Forward,
        [LookupString("glyphicon glyphicon-fast-forward")] FastForward,
        [LookupString("glyphicon glyphicon-step-forward")] StepForward,
        [LookupString("glyphicon glyphicon-eject")] Eject,
        [LookupString("glyphicon glyphicon-chevron-left")] ChevronLeft,
        [LookupString("glyphicon glyphicon-chevron-right")] ChevronRight,
        [LookupString("glyphicon glyphicon-plus-sign")] PlusSign,
        [LookupString("glyphicon glyphicon-minus-sign")] MinusSign,
        [LookupString("glyphicon glyphicon-remove-sign")] RemoveSign,
        [LookupString("glyphicon glyphicon-ok-sign")] OkSign,
        [LookupString("glyphicon glyphicon-question-sign")] QuestionSign,
        [LookupString("glyphicon glyphicon-info-sign")] InfoSign,
        [LookupString("glyphicon glyphicon-screenshot")] Screenshot,
        [LookupString("glyphicon glyphicon-remove-circle")] RemoveCircle,
        [LookupString("glyphicon glyphicon-ok-circle")] OkCircle,
        [LookupString("glyphicon glyphicon-ban-circle")] BanCircle,
        [LookupString("glyphicon glyphicon-arrow-left")] ArrowLeft,
        [LookupString("glyphicon glyphicon-arrow-right")] ArrowRight,
        [LookupString("glyphicon glyphicon-arrow-up")] ArrowUp,
        [LookupString("glyphicon glyphicon-arrow-down")] ArrowDown,
        [LookupString("glyphicon glyphicon-share-alt")] ShareAlt,
        [LookupString("glyphicon glyphicon-resize-full")] ResizeFull,
        [LookupString("glyphicon glyphicon-resize-small")] ResizeSmall,
        [LookupString("glyphicon glyphicon-exclamation-sign")] ExclamationSign,
        [LookupString("glyphicon glyphicon-gift")] Gift,
        [LookupString("glyphicon glyphicon-leaf")] Leaf,
        [LookupString("glyphicon glyphicon-fire")] Fire,
        [LookupString("glyphicon glyphicon-eye-open")] EyeOpen,
        [LookupString("glyphicon glyphicon-eye-close")] EyeClose,
        [LookupString("glyphicon glyphicon-warning-sign")] WarningSign,
        [LookupString("glyphicon glyphicon-plane")] Plane,
        [LookupString("glyphicon glyphicon-calendar")] Calendar,
        [LookupString("glyphicon glyphicon-random")] Random,
        [LookupString("glyphicon glyphicon-comment")] Comment,
        [LookupString("glyphicon glyphicon-magnet")] Magnet,
        [LookupString("glyphicon glyphicon-chevron-up")] ChevronUp,
        [LookupString("glyphicon glyphicon-chevron-down")] ChevronDown,
        [LookupString("glyphicon glyphicon-retweet")] Retweet,
        [LookupString("glyphicon glyphicon-shopping-cart")] ShoppingCart,
        [LookupString("glyphicon glyphicon-folder-close")] FolderClose,
        [LookupString("glyphicon glyphicon-folder-open")] FolderOpen,
        [LookupString("glyphicon glyphicon-resize-vertical")] ResizeVertical,
        [LookupString("glyphicon glyphicon-resize-horizontal")] ResizeHorizontal,
        [LookupString("glyphicon glyphicon-hdd")] Hdd,
        [LookupString("glyphicon glyphicon-bullhorn")] Bullhorn,
        [LookupString("glyphicon glyphicon-bell")] Bell,
        [LookupString("glyphicon glyphicon-certificate")] Certificate,
        [LookupString("glyphicon glyphicon-thumbs-up")] ThumbsUp,
        [LookupString("glyphicon glyphicon-thumbs-down")] ThumbsDown,
        [LookupString("glyphicon glyphicon-hand-right")] HandRight,
        [LookupString("glyphicon glyphicon-hand-left")] HandLeft,
        [LookupString("glyphicon glyphicon-hand-up")] HandUp,
        [LookupString("glyphicon glyphicon-hand-down")] HandDown,
        [LookupString("glyphicon glyphicon-circle-arrow-right")] CircleArrowRight,
        [LookupString("glyphicon glyphicon-circle-arrow-left")] CircleArrowLeft,
        [LookupString("glyphicon glyphicon-circle-arrow-up")] CircleArrowUp,
        [LookupString("glyphicon glyphicon-circle-arrow-down")] CircleArrowDown,
        [LookupString("glyphicon glyphicon-globe")] Globe,
        [LookupString("glyphicon glyphicon-wrench")] Wrench,
        [LookupString("glyphicon glyphicon-tasks")] Tasks,
        [LookupString("glyphicon glyphicon-filter")] Filter,
        [LookupString("glyphicon glyphicon-briefcase")] Briefcase,
        [LookupString("glyphicon glyphicon-fullscreen")] Fullscreen,
        [LookupString("glyphicon glyphicon-dashboard")] Dashboard,
        [LookupString("glyphicon glyphicon-paperclip")] Paperclip,
        [LookupString("glyphicon glyphicon-heart-empty")] HeartEmpty,
        [LookupString("glyphicon glyphicon-link")] Link,
        [LookupString("glyphicon glyphicon-phone")] Phone,
        [LookupString("glyphicon glyphicon-pushpin")] Pushpin,
        [LookupString("glyphicon glyphicon-usd")] Usd,
        [LookupString("glyphicon glyphicon-gbp")] Gbp,
        [LookupString("glyphicon glyphicon-sort")] Sort,
        [LookupString("glyphicon glyphicon-sort-by-alphabet")] SortByAlphabet,
        [LookupString("glyphicon glyphicon-sort-by-alphabet-alt")] SortByAlphabetAlt,
        [LookupString("glyphicon glyphicon-sort-by-order")] SortByOrder,
        [LookupString("glyphicon glyphicon-sort-by-order-alt")] SortByOrderAlt,
        [LookupString("glyphicon glyphicon-sort-by-attributes")] SortByAttributes,
        [LookupString("glyphicon glyphicon-sort-by-attributes-alt")] SortByAttributesAlt,
        [LookupString("glyphicon glyphicon-unchecked")] Unchecked,
        [LookupString("glyphicon glyphicon-expand")] Expand,
        [LookupString("glyphicon glyphicon-collapse-down")] CollapseDown,
        [LookupString("glyphicon glyphicon-collapse-up")] CollapseUp,
        [LookupString("glyphicon glyphicon-log-in")] LogIn,
        [LookupString("glyphicon glyphicon-flash")] Flash,
        [LookupString("glyphicon glyphicon-log-out")] LogOut,
        [LookupString("glyphicon glyphicon-new-window")] NewWindow,
        [LookupString("glyphicon glyphicon-record")] Record,
        [LookupString("glyphicon glyphicon-save")] Save,
        [LookupString("glyphicon glyphicon-open")] Open,
        [LookupString("glyphicon glyphicon-saved")] Saved,
        [LookupString("glyphicon glyphicon-import")] Import,
        [LookupString("glyphicon glyphicon-export")] Export,
        [LookupString("glyphicon glyphicon-send")] Send,
        [LookupString("glyphicon glyphicon-floppy-disk")] FloppyDisk,
        [LookupString("glyphicon glyphicon-floppy-saved")] FloppySaved,
        [LookupString("glyphicon glyphicon-floppy-remove")] FloppyRemove,
        [LookupString("glyphicon glyphicon-floppy-save")] FloppySave,
        [LookupString("glyphicon glyphicon-floppy-open")] FloppyOpen,
        [LookupString("glyphicon glyphicon-credit-card")] CreditCard,
        [LookupString("glyphicon glyphicon-transfer")] Transfer,
        [LookupString("glyphicon glyphicon-cutlery")] Cutlery,
        [LookupString("glyphicon glyphicon-header")] Header,
        [LookupString("glyphicon glyphicon-compressed")] Compressed,
        [LookupString("glyphicon glyphicon-earphone")] Earphone,
        [LookupString("glyphicon glyphicon-phone-alt")] PhoneAlt,
        [LookupString("glyphicon glyphicon-tower")] Tower,
        [LookupString("glyphicon glyphicon-stats")] Stats,
        [LookupString("glyphicon glyphicon-sd-video")] SdVideo,
        [LookupString("glyphicon glyphicon-hd-video")] HdVideo,
        [LookupString("glyphicon glyphicon-subtitles")] Subtitles,
        [LookupString("glyphicon glyphicon-sound-stereo")] SoundStereo,
        [LookupString("glyphicon glyphicon-sound-dolby")] SoundDolby,
        [LookupString("glyphicon glyphicon-sound-5-1")] Sound51,
        [LookupString("glyphicon glyphicon-sound-6-1")] Sound61,
        [LookupString("glyphicon glyphicon-sound-7-1")] Sound71,
        [LookupString("glyphicon glyphicon-copyright-mark")] CopyrightMark,
        [LookupString("glyphicon glyphicon-registration-mark")] RegistrationMark,
        [LookupString("glyphicon glyphicon-cloud-download")] CloudDownload,
        [LookupString("glyphicon glyphicon-cloud-upload")] CloudUpload,
        [LookupString("glyphicon glyphicon-tree-conifer")] TreeConifer,
        [LookupString("glyphicon glyphicon-tree-deciduous")] TreeDeciduous,
        [LookupString("glyphicon glyphicon-cd")] Cd,
        [LookupString("glyphicon glyphicon-save-file")] SaveFile,
        [LookupString("glyphicon glyphicon-open-file")] OpenFile,
        [LookupString("glyphicon glyphicon-level-up")] LevelUp,
        [LookupString("glyphicon glyphicon-copy")] Copy,
        [LookupString("glyphicon glyphicon-paste")] Paste,
        [LookupString("glyphicon glyphicon-alert")] Alert,
        [LookupString("glyphicon glyphicon-equalizer")] Equalizer,
        [LookupString("glyphicon glyphicon-king")] King,
        [LookupString("glyphicon glyphicon-queen")] Queen,
        [LookupString("glyphicon glyphicon-pawn")] Pawn,
        [LookupString("glyphicon glyphicon-bishop")] Bishop,
        [LookupString("glyphicon glyphicon-knight")] Knight,
        [LookupString("glyphicon glyphicon-baby-formula")] BabyFormula,
        [LookupString("glyphicon glyphicon-tent")] Tent,
        [LookupString("glyphicon glyphicon-blackboard")] Blackboard,
        [LookupString("glyphicon glyphicon-bed")] Bed,
        [LookupString("glyphicon glyphicon-apple")] Apple,
        [LookupString("glyphicon glyphicon-erase")] Erase,
        [LookupString("glyphicon glyphicon-hourglass")] Hourglass,
        [LookupString("glyphicon glyphicon-lamp")] Lamp,
        [LookupString("glyphicon glyphicon-duplicate")] Duplicate,
        [LookupString("glyphicon glyphicon-piggy-bank")] PiggyBank,
        [LookupString("glyphicon glyphicon-scissors")] Scissors,
        [LookupString("glyphicon glyphicon-bitcoin")] Bitcoin,
        [LookupString("glyphicon glyphicon-btc")] Btc,
        [LookupString("glyphicon glyphicon-xbt")] Xbt,
        [LookupString("glyphicon glyphicon-yen")] Yen,
        [LookupString("glyphicon glyphicon-jpy")] Jpy,
        [LookupString("glyphicon glyphicon-ruble")] Ruble,
        [LookupString("glyphicon glyphicon-rub")] Rub,
        [LookupString("glyphicon glyphicon-scale")] Scale,
        [LookupString("glyphicon glyphicon-ice-lolly")] IceLolly,
        [LookupString("glyphicon glyphicon-ice-lolly-tasted")] IceLollyTasted,
        [LookupString("glyphicon glyphicon-education")] Education,
        [LookupString("glyphicon glyphicon-option-horizontal")] OptionHorizontal,
        [LookupString("glyphicon glyphicon-option-vertical")] OptionVertical,
        [LookupString("glyphicon glyphicon-menu-hamburger")] MenuHamburger,
        [LookupString("glyphicon glyphicon-modal-window")] ModalWindow,
        [LookupString("glyphicon glyphicon-oil")] Oil,
        [LookupString("glyphicon glyphicon-grain")] Grain,
        [LookupString("glyphicon glyphicon-sunglasses")] Sunglasses,
        [LookupString("glyphicon glyphicon-text-size")] TextSize,
        [LookupString("glyphicon glyphicon-text-color")] TextColor,
        [LookupString("glyphicon glyphicon-text-background")] TextBackground,
        [LookupString("glyphicon glyphicon-object-align-top")] ObjectAlignTop,
        [LookupString("glyphicon glyphicon-object-align-bottom")] ObjectAlignBottom,
        [LookupString("glyphicon glyphicon-object-align-horizontal")] ObjectAlignHorizontal,
        [LookupString("glyphicon glyphicon-object-align-left")] ObjectAlignLeft,
        [LookupString("glyphicon glyphicon-object-align-vertical")] ObjectAlignVertical,
        [LookupString("glyphicon glyphicon-object-align-right")] ObjectAlignRight,
        [LookupString("glyphicon glyphicon-triangle-right")] TriangleRight,
        [LookupString("glyphicon glyphicon-triangle-left")] TriangleLeft,
        [LookupString("glyphicon glyphicon-triangle-bottom")] TriangleBottom,
        [LookupString("glyphicon glyphicon-triangle-top")] TriangleTop,
        [LookupString("glyphicon glyphicon-console")] Console,
        [LookupString("glyphicon glyphicon-superscript")] Superscript,
        [LookupString("glyphicon glyphicon-subscript")] Subscript,
        [LookupString("glyphicon glyphicon-menu-left")] MenuLeft,
        [LookupString("glyphicon glyphicon-menu-right")] MenuRight,
        [LookupString("glyphicon glyphicon-menu-down")] MenuDown,
        [LookupString("glyphicon glyphicon-menu-up")] MenuUp
    }

    [LookupEnum]
    public enum TooltipPlacement
    {
        [LookupString("left")]
        Left,
        [LookupString("top")]
        Top,
        [LookupString("right")]
        Right,
        [LookupString("bottom")]
        Bottom
    }
}
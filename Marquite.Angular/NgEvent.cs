using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;

namespace Marquite.Angular
{
    /// <summary>
    /// Events supported by AngularJS
    /// </summary>
    [LookupEnum]
    public enum NgEvent
    {
        /// <summary>
        /// A blur event fires when an element has lost focus.
        /// </summary>
        [LookupString("ng-blur")] Blur,

        /// <summary>
        /// Evaluate the given expression when the user changes the input. 
        /// The expression is evaluated immediately, 
        /// unlike the JavaScript onchange event which only triggers at the end of a 
        /// change (usually, when the user leaves the form element or presses the return key).
        /// </summary>
        [LookupString("ng-change")] Change,

        /// <summary>
        /// Fires when an element is clicked.
        /// </summary>
        [LookupString("ng-click")] Click,

        /// <summary>
        /// Fires on copy event
        /// </summary>
        [LookupString("ng-copy")] Copy,

        /// <summary>
        /// Fires on cut event
        /// </summary>
        [LookupString("ng-cut")] Cut,

        /// <summary>
        /// Fires on cut event
        /// </summary>
        [LookupString("ng-paste")]
        Paste,

        /// <summary>
        /// Fires on double mouse click event
        /// </summary>
        [LookupString("ng-dblclick")] Dblclick,

        /// <summary>
        /// Fires on element focused event. 
        /// Note: As the focus event is executed synchronously when calling input.focus() 
        /// AngularJS executes the expression using scope.$evalAsync if 
        /// the event is fired during an $apply to ensure a consistent state.
        /// </summary>
        [LookupString("ng-focus")] Focus,

        /// <summary>
        /// Fires on key down event
        /// </summary>
        [LookupString("ng-keydown")] Keydown,

        /// <summary>
        /// Fires on key press event
        /// </summary>
        [LookupString("ng-keypress")] Keypress,

        /// <summary>
        /// Fires on key up event
        /// </summary>
        [LookupString("ng-keyup")] Keyup,

        /// <summary>
        /// Fires on mouse button down event
        /// </summary>
        [LookupString("ng-mousedown")] Mousedown,

        /// <summary>
        /// Fires on mouse enter element event
        /// </summary>
        [LookupString("ng-mouseenter")] Mouseenter,

        /// <summary>
        /// Fires on mouse leave element event
        /// </summary>
        [LookupString("ng-mouseleave")] Mouseleave,

        /// <summary>
        /// Fires on mouse move over element event
        /// </summary>
        [LookupString("ng-mousemove")] Mousemove,

        /// <summary>
        /// Fires on mouse over element event
        /// </summary>
        [LookupString("ng-mouseover")] Mouseover,

        /// <summary>
        /// Fires on mouse up event
        /// </summary>
        [LookupString("ng-mouseup")] Mouseup,

        /// <summary>
        /// Fires when an element is swiped to the left on a touchscreen device. 
        /// A leftward swipe is a quick, right-to-left slide of the finger. 
        /// Though ngSwipeLeft is designed for touch-based devices, 
        /// it will work with a mouse click and drag too.
        /// </summary>
        [LookupString("ng-swipe-left")] SwipeLeft,

        /// <summary>
        /// Fires when an element is swiped to the right on a touchscreen device. 
        /// A rightward swipe is a quick, left-to-right slide of the finger. 
        /// Though ngSwipeRight is designed for touch-based devices, 
        /// it will work with a mouse click and drag too.
        /// </summary>
        [LookupString("ng-swipe-right")] SwipeRight,

    }
}

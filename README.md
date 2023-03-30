<div>
    <h1>TrueBorderlessBrowser</h1>
    <p>A browser that removes the unneccesary tabs, and titlebar, and with using online video players (My application is
        with youtube the fullscreen feature sets it only "fullscreen" to the window size.) </p>
    <p>This is a work in progress: currently controls are hard-coded (to youtube) and limited functionality. (if the
        concept proves great, we can expand) </p>
</div>
<div>
    <h2>Introduction</h2>
    <p>TrueBorderlessBrowser does exactly that: give you a browser that is borderless, adjustable transparency and the
        ability to have more information on your screen at any given time. - A long list of things to do to make it a
        great functional browser, but so far the personal application is to show streamed video content in a flexible
        adjustabel and transparacy controlled environment.</p>
</div>
<div>
    <h2>Controls (V1)</h2>
    <ul>
        <li>holding ctrl + shift - Shifts control to the window (only if active)</li>
        <li>holding ctrl + shift + alt makes the window dragable (and not interactable) </li>
        <li>holding ctrl + shift + with Tilde '`~' makes the Program exit.</li>
    </ul>
    <h2>Notes: EXPERIMENTAL BRANCH</h2>
    <ul>
    <li>When you focus on the window (via alt+tab) you can capture the keyboard and mouse using ctrl+chift, and work inside the window without holding them down. </li>
    <li>When the mouse leaves the window, the window becomes an overlay, and unclickable (it's set.) to unset or control follow above </li>
    <li>when the window is focussed controls above work, but... </li>
    <li>Issue: low level keyboard hook gets suckedup by GC. work around is that the shortcut keys only works when the window is focussed (therefore necessary to do either one of two things <ol><li>Create more potent global hooking and advise gc to not remove them.</li><li>create a systray interface for capturing controls, and add checkbox of 'automaticaly become unclicable' and then add all the settings to systray, then making the standard window not focussable by any other means (ie. invisible to alt+tab and not in taskbar.</li></ol></li>
        <li>Watch THis Space. If you want more of this, support the dev(s) to 'incentivise' this project going forward.
        </li>
    </ul>
    <h2>Planning</h2>
    <h3>TODO:</h3>
    <ul>
        <li>holding ctrl makes interaction possible, leaving ctrl makes the window clicktrhough but overlay. (** this
            will go on the first experimental branch.)</li>
        <li>Make WebPluggins that forces certain elements to downsize that this browser can be used on smaller screens
            to maximise important information and downsize unimportant things. (I think about making it natively
            advertising and popup blocked)
        </li>
        <li></li>
    </ul>
</div>

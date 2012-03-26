function setMedia(mediaUrl) {
    var player = getPlayer();
    player.SetMedia(mediaUrl);
}

function play() {
    var player = getPlayer();
    player.Play();
}

function pause() {
    var player = getPlayer();
    player.Pause();
}

function stop() {
    var player = getPlayer();
    player.Stop();
}

function seekToPosition(time) {
    var player = getPlayer();
    player.SeekToPosition(time);
}

function takeScreenshot() {
    var player = getPlayer();
    player.TakeScreenshot();
}

function showGraph() {
    var player = getPlayer();
    player.ShowGraph();
}

function getPlayer() {
    var control = document.getElementById("silverlightControl");
    return control.Content.Player;
}

function onSilverlightError(sender, args) {
    var appSource = "";
    if (sender != null && sender != 0) {
        appSource = sender.getHost().Source;
    }

    var errorType = args.ErrorType;
    var iErrorCode = args.ErrorCode;

    if (errorType == "ImageError" || errorType == "MediaError") {
        return;
    }

    var errMsg = "Unhandled Error in Silverlight Application " + appSource + "\n";

    errMsg += "Code: " + iErrorCode + "    \n";
    errMsg += "Category: " + errorType + "       \n";
    errMsg += "Message: " + args.ErrorMessage + "     \n";

    if (errorType == "ParserError") {
        errMsg += "File: " + args.xamlFile + "     \n";
        errMsg += "Line: " + args.lineNumber + "     \n";
        errMsg += "Position: " + args.charPosition + "     \n";
    }
    else if (errorType == "RuntimeError") {
        if (args.lineNumber != 0) {
            errMsg += "Line: " + args.lineNumber + "     \n";
            errMsg += "Position: " + args.charPosition + "     \n";
        }
        errMsg += "MethodName: " + args.methodName + "     \n";
    }

    throw new Error(errMsg);
}
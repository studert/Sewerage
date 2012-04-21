(function(window, undefined) {
    SilverlightPlayer = function() {
        var self = this;

        var getPlayer = function() {
            var control = document.getElementById("silverlightControl");
            return control.Content.Player;
        };

        self.setMedia = function(mediaUrl) {
            getPlayer().SetMedia(mediaUrl);
        };

        self.play = function() {
            getPlayer().Play();
        };

        self.pause = function() {
            getPlayer().Pause();
        };

        self.stop = function() {
            getPlayer().Stop();
        };

        self.seekToPosition = function(time) {
            getPlayer().SeekToPosition(time);
        };

        self.takeScreenshot = function() {
            getPlayer().TakeScreenshot();
        };

        self.showGraph = function() {
            getPlayer().ShowGraph();
        };
    };
})(window);
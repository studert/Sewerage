(function (window, undefined) {
    SilverlightPlayer = function () {
        var self = this;

        var getPlayer = function () {
            var control = document.getElementById("silverlightControl");
            if (control === null || control.Content === undefined) return null;
            return control.Content.Player;
        };

        self.setMedia = function (mediaUrl) {
            var player = getPlayer();
            if (!player) return;
            
            player.SetMedia(mediaUrl);
        };

        self.play = function () {
            var player = getPlayer();
            if (!player) return;
            
            player.Play();
        };

        self.pause = function () {
            var player = getPlayer();
            if (!player) return;
            
            player.Pause();
        };

        self.stop = function () {
            var player = getPlayer();
            if (!player) return;
            
            player.Stop();
        };

        self.seekToPosition = function (time) {
            var player = getPlayer();
            if (!player) return;
            
            player.SeekToPosition(time);
        };

        self.takeScreenshot = function () {
            var player = getPlayer();
            if (!player) return;
            
            player.TakeScreenshot();
        };

        self.showGraph = function () {
            var player = getPlayer();
            if (!player) return;
            
            player.ShowGraph();
        };
    };
})(window);
function App() {
    var run = function () {
        var blazor = window.Blazor;

        blazor.start();
    };

    return {
	    run: run
    };
}

var app = new App();
app.run();
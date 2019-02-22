$(function () {

    // The view model that is bound to our view
    var ViewModel = function () {
        var self = this;

        // Whether we're connected or not
        self.connected = ko.observable(false);

        // Collection of machines that are connected
        self.vehicles = ko.observableArray();
    };

    // Instantiate the viewmodel..
    var vm = new ViewModel();

    // .. and bind it to the view
    ko.applyBindings(vm, $("#myVehicles")[0]);

    // Get a reference to our hub
    var hub = $.connection.vehicleHub;

    // Add a handler to receive updates from the server
    hub.client.vhehicleStatusMessage = function (Id, Status) {
        
        var vehicle = {
            Id: Id,
            Status: Status
        };

        var vehicleModel = ko.mapping.fromJS(vehicle);

        // Check if we already have it:
        var match = ko.utils.arrayFirst(vm.vehicles(), function (item) {
            return item.Id() == Id;
        });
        
        if (!match)
            vm.vehicles.push(vehicleModel);
        else {
            var index = vm.vehicles.indexOf(match);
            vm.vehicles.replace(vm.vehicles()[index], vehicleModel);
        }
    };

    // Start the connectio
    $.connection.hub.start().done(function () {
        vm.connected(true);
    });
});
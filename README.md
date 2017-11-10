# AirTrafficControl

## Instructions

Run `AirTrafficControl.exe` to open the UI.

## Design

* [Aircraft](AirTrafficControl/Model/Aircraft.cs)
** This is the datastructure that gets queued.
** Has:
*** [Size](AirTrafficControl/Model/AcSize.cs)
*** [Type](AirTrafficControl/Model/AcType.cs)
* [Request](AirTrafficControl/Request)
** Request is the base class for all of the request types.
** The subclasses define the actions that are available.
* [AirTrafficController](AirTrafficControl/ATC/AirTrafficController.cs)
** This provides the main traffic control logic.
** aqmRequestProcess(Request req) processes requests based on the type they are.
** It uses a queue (see below) internally.
* [Queue](AirTrafficControl/ATC/Queue)
** The IAtcQueue interface allows different backing logic to be used for the queues.
** AtcQueueLinq uses a list to queue and searches with Linq statements to dequeue.
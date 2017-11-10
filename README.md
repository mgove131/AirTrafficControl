# AirTrafficControl

## Instructions

Run `AirTrafficControl.exe` to open the UI.

## Design

* [Aircraft](AirTrafficControl/Model/Aircraft.cs)
  * This is the datastructure that gets queued.
  * Has:
    * [Size](AirTrafficControl/Model/AcSize.cs)
    * [Type](AirTrafficControl/Model/AcType.cs)
* [Request](AirTrafficControl/Model/Request)
  * Defines what actions are available.
  * [Request](AirTrafficControl/Model/Request/Request.cs) is the base class for all of the request types.
  * The subclasses are the actions.
* [AirTrafficController](AirTrafficControl/ATC/AirTrafficController.cs)
  * This provides the main traffic control logic.
  * aqmRequestProcess(Request req) processes requests based on the type they are.
  * It uses a queue (see below) internally.
* [Queue](AirTrafficControl/ATC/Queue)
  * The [IAtcQueue](AirTrafficControl/ATC/Queue/IAtcQueue.cs) interface allows different backing logic to be used for the queues.
  * [AtcQueueLinq](AirTrafficControl/ATC/Queue/AtcQueueLinq.cs)
    * The current implementation available.
    * It uses a list to queue and searches with Linq statements to dequeue.
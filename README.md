# AirTrafficControl

## Description

* Air-traffic control system that manages a queue of aircraft in an airport.
* Aircraft can be enqueued and dequeued.
* Aircraft have a type and size.
* Dequeue order
  * Large passenger aircraft
  * Small passenger aircraft
  * Large cargo aircraft
  * Small cargo aircraft

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
    * It uses a list to hold the queued aircrafts. 
	* It searches with the list with Linq statements to dequeue the correct aircraft.
  * [AtcQueueBuckets](AirTrafficControl/ATC/Queue/AtcQueueBuckets.cs)
    * Stores the aircraft in different queues based on the type and size. 
	* Dequeuing is more efficient because it just has to see if a queue has any aircraft, not search it.
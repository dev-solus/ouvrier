import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Location } from '../Models';
@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {
  // send object to be edited to parent component
  @Output() eventToParent = new EventEmitter<any>();
  @Output() eventToParent2 = new EventEmitter<any>();
  @Input() showMarker = false;
  // google maps zoom level
  zoom = 6;
  // initial center position for the map
  @Input() lat; // = 33.927251;
  @Input() lng; // = -6.887098;

  @Input() markers: Marker[] = [];

  constructor() { }

  ngOnInit(): void {
    if (this.lat && this.lng && this.showMarker) {
      this.markers.push({ lat: this.lat, lng: this.lng, draggable: false });
    }
  }

  clickedMarker(label: Location, index: number) {
    // console.log(label);
    // console.log(`clicked the marker: ${label || index}`);
    this.eventToParent2.next(label.users[0]);
  }

  mapClicked($event: any) {
    // console.log($event);
    if (this.showMarker) {
      this.lat = $event.coords.lat;
      this.lng = $event.coords.lng;
      this.markers.shift();
      this.markers.push({ lat: this.lat, lng: this.lng, draggable: false });
      this.eventToParent.next({ lat: $event.coords.lat, lng: $event.coords.lng });
    }
    // console.log('$event.coords.lat = ', $event.coords.lat);
    // console.log('$event.coords.lng = ', $event.coords.lng);
    // this.markers.push({
    //   lat: $event.coords.lat,
    //   lng: $event.coords.lng,
    //   draggable: true
    // });
  }

  markerDragEnd($event: any) {
    console.log('dragEnd', $event);
  }


}

// just an interface for type safety.
interface Marker {
  lat: number;
  lng: number;
  label?: string;
  draggable: boolean;
}

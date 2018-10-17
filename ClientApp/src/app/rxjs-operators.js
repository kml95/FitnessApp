// import 'rxjs/Rx'; // adds ALL RxJS statics & operators to Observable

// See node_module/rxjs/Rxjs.js
// Import just the rxjs statics and operators we need for THIS app.

// Statics
import { throwError } from 'rxjs/observable'

// Operators
import { catchError, debounceTime, distinctUntilChanged, map, switchMap, toPromise } from 'rxjs/operators';


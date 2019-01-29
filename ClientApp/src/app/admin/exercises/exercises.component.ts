import { Component, OnInit } from '@angular/core';
import { ExerciseService } from 'src/app/shared/services/exercise.service';
import { Muscle } from 'src/app/shared/models/exercise.interface';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-exercises',
  templateUrl: './exercises.component.html',
  styleUrls: ['./exercises.component.scss']
})
export class ExercisesComponent implements OnInit {

  exercises: Exercise[];
  count: number;
  pages: number;
  itemsPerPage = 7;
  currentPage = 1;
  index = 1;
  createAlert: boolean;
  editedAlert: boolean;
  editedName: string;

  constructor(private exerciseService: ExerciseService) { }

  ngOnInit() {
    this.exerciseService.count().subscribe(result => {
      this.count = result;
      if (this.count !== 0) {
        this.exerciseService.getRange(0, 7).subscribe(exercises => {
          this.exercises = exercises;
        });
      }
      if (this.count % this.itemsPerPage === 0) {
        this.pages = Math.floor(this.count / this.itemsPerPage);
      } else {
        this.pages = Math.floor(this.count / this.itemsPerPage) + 1;
      }
    });
  }

  getExercises(page: number) {
    this.exerciseService.getRange((page - 1) * this.itemsPerPage, 7).subscribe(exercises => {
      this.exercises = exercises;
    });
    if (!(this.index + 3 === this.pages) && !(this.index - page === 0) && !(this.pages === page)) {
      this.index = page - 1;
    }
    if ((this.index - page === 0) && page !== 1) {
      this.index = page - 1;
    }
    this.currentPage = page;
  }

  createExercise(form: NgForm) {
    this.exerciseService.create(form.value.name, form.value.stage, form.value.muscle).subscribe(exercise => {
      this.createAlert = true;
    });
  }

  resetAddForm(form: NgForm) {
    form.setValue({ name: '', stage: '', muscle: '' });
  }

  initEditForm(editForm: NgForm, exercise: Exercise) {
    this.editedName = exercise.name;
    editForm.setValue({ name: exercise.name, stage: exercise.stage, muscle: exercise.muscle});
  }

  editExercise(form: NgForm) {
    this.exerciseService.getIdByName(this.editedName).subscribe(id => {
      this.exerciseService.update(id, new Exercise(form.value.name, form.value.stage, form.value.muscle)).subscribe(exercise => {
        this.editedAlert = true;
        this.exerciseService.getRange((this.currentPage - 1) * this.itemsPerPage, 7).subscribe(exercises => {
          this.exercises = exercises;
        });
      });
    });
  }

  deleteExercise(name: string) {
    this.exerciseService.getIdByName(name).subscribe(id => {
      this.exerciseService.delete(id).subscribe(exercise => {
        this.exerciseService.getRange((this.currentPage - 1) * this.itemsPerPage, 7).subscribe(exercises => {
          this.exercises = exercises;
        });
      });
    });
  }
}

class Exercise {
  constructor(
    public name: string,
    public stage: number,
    public muscle: Muscle) { }
}

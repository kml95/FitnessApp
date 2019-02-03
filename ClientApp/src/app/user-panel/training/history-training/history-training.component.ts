import { Component, OnInit } from '@angular/core';
import { Training, TrainingAim } from 'src/app/shared/models/training.interface';
import { TrainingService } from 'src/app/shared/services/training.service';
import { Exercise, Muscle } from 'src/app/shared/models/exercise.interface';

@Component({
  selector: 'app-history-training',
  templateUrl: './history-training.component.html',
  styleUrls: ['./history-training.component.scss']
})
export class HistoryTrainingComponent implements OnInit {
  trainings: Training[];
  model: ExerciseViewModel;
  ifTraining: boolean;

  constructor(private trainingService: TrainingService) { this.ifTraining = false; }

  ngOnInit() {
    this.trainingService.getLast(5).subscribe(trainings => {
      this.trainings = trainings;
    }, (error) => this.trainings = null);
  }

  showTraining(page: number) {
    const tmpChest = new Array<Exercise>();
    const tmpBack = new Array<Exercise>();
    const tmpLegs = new Array<Exercise>();
    const tmpShoulders = new Array<Exercise>();
    const tmpTriceps = new Array<Exercise>();
    const tmpBiceps = new Array<Exercise>();
    const tmpAbs = new Array<Exercise>();

    this.trainings[page].exercises.forEach(element => {
      switch (element.muscle) {
        case Muscle.CHEST:
          tmpChest.push(element);
          break;
        case Muscle.BACK:
          tmpBack.push(element);
          break;
        case Muscle.LEGS:
          tmpLegs.push(element);
          break;
        case Muscle.SHOULDERS:
          tmpShoulders.push(element);
          break;
        case Muscle.BICEPS:
          tmpBiceps.push(element);
          break;
        case Muscle.TRICEPS:
          tmpTriceps.push(element);
          break;
        case Muscle.ABS:
          tmpAbs.push(element);
          break;
        default:
          break;
      }
    });

    tmpChest.sort((a, b) => a.stage - b.stage);
    tmpBack.sort((a, b) => a.stage - b.stage);
    tmpLegs.sort((a, b) => a.stage - b.stage);
    tmpShoulders.sort((a, b) => a.stage - b.stage);
    tmpBiceps.sort((a, b) => a.stage - b.stage);
    tmpTriceps.sort((a, b) => a.stage - b.stage);
    tmpAbs.sort((a, b) => a.stage - b.stage);
    this.model = new ExerciseViewModel(
      this.trainings[page].days,
      tmpChest.map(c => c.name),
      tmpBack.map(b => b.name),
      tmpLegs.map(l => l.name),
      tmpShoulders.map(s => s.name),
      tmpBiceps.map(b => b.name),
      tmpTriceps.map(t => t.name),
      tmpAbs.map(a => a.name)
    );
    for (let index = 0; index < tmpChest.length; index++) {
      switch (this.trainings[page].aim) {
        case TrainingAim.MASS:
          switch (index) {
            case 0:
              this.model.chest[index] = `${index + 1}. ${this.model.chest[index].toString()} - 4 serie 12/10/8/6`;
              break;
            case 1:
              this.model.chest[index] = `${index + 1}. ${this.model.chest[index].toString()} - 3 serie 12/10/8`;
              break;
            case 2:
              this.model.chest[index] = `${index + 1}. ${this.model.chest[index].toString()} - 3 serie 12/10/10`;
              break;
          }
          break;
        case TrainingAim.REDUCTION:
          switch (index) {
            case 0:
              this.model.chest[index] = `${index + 1}. ${this.model.chest[index].toString()} - 4 serie 15/12/12`;
              break;
            case 1:
              this.model.chest[index] = `${index + 1}. ${this.model.chest[index].toString()} - 3 serie 12/12/12`;
              break;
            case 2:
              this.model.chest[index] = `${index + 1}. ${this.model.chest[index].toString()} - 3 serie 12/12/12`;
              break;
          }
          break;
        case TrainingAim.STRENGTH:
          switch (index) {
            case 0:
              this.model.chest[index] = `${index + 1}. ${this.model.chest[index].toString()} - 5 serii 8/5/5/3/1`;
              break;
            case 1:
              this.model.chest[index] = `${index + 1}. ${this.model.chest[index].toString()} - 2 serie 10/8`;
              break;
            case 2:
              this.model.chest[index] = `${index + 1}. ${this.model.chest[index].toString()} - 3 serie 12/10/10`;
              break;
          }
          break;
      }
    }
    for (let index = 0; index < tmpBack.length; index++) {
      switch (this.trainings[page].aim) {
        case TrainingAim.MASS:
          switch (index) {
            case 0:
              this.model.back[index] = `${index + 1}. ${this.model.back[index].toString()} - 4 serie 10/8/6/6`;
              break;
            case 1:
              this.model.back[index] = `${index + 1}. ${this.model.back[index].toString()} - 3 serie 12/10/8`;
              break;
            case 2:
              this.model.back[index] = `${index + 1}. ${this.model.back[index].toString()} - 3 serie 12/10/10`;
              break;
          }
          break;
        case TrainingAim.REDUCTION:
          switch (index) {
            case 0:
              this.model.back[index] = `${index + 1}. ${this.model.back[index].toString()} - 4 serie 15/12/12`;
              break;
            case 1:
              this.model.back[index] = `${index + 1}. ${this.model.back[index].toString()} - 3 serie 12/12/12`;
              break;
            case 2:
              this.model.back[index] = `${index + 1}. ${this.model.back[index].toString()} - 3 serie 15/12/12`;
              break;
          }
          break;
        case TrainingAim.STRENGTH:
          switch (index) {
            case 0:
              this.model.back[index] = `${index + 1}. ${this.model.back[index].toString()} - 5 serii 6/5/4/3/2`;
              break;
            case 1:
              this.model.back[index] = `${index + 1}. ${this.model.back[index].toString()} - 2 serie 10/8`;
              break;
            case 2:
              this.model.back[index] = `${index + 1}. ${this.model.back[index].toString()} - 3 serie 8/6/6`;
              break;
          }
          break;
      }
    }
    for (let index = 0; index < tmpLegs.length; index++) {
      switch (this.trainings[page].aim) {
        case TrainingAim.MASS:
          switch (index) {
            case 0:
              this.model.legs[index] = `${index + 1}. ${this.model.legs[index].toString()} - 4 serie 8/8/6/5`;
              break;
            case 1:
              this.model.legs[index] = `${index + 1}. ${this.model.legs[index].toString()} - 3 serie 10/8/8`;
              break;
            case 2:
              this.model.legs[index] = `${index + 1}. ${this.model.legs[index].toString()} - 3 serie 12/10/10`;
              break;
          }
          break;
        case TrainingAim.REDUCTION:
          switch (index) {
            case 0:
              this.model.legs[index] = `${index + 1}. ${this.model.legs[index].toString()} - 4 serie 12/10/10`;
              break;
            case 1:
              this.model.legs[index] = `${index + 1}. ${this.model.legs[index].toString()} - 3 serie 15/12/12`;
              break;
            case 2:
              this.model.legs[index] = `${index + 1}. ${this.model.legs[index].toString()} - 3 serie 15/15/15`;
              break;
          }
          break;
        case TrainingAim.STRENGTH:
          switch (index) {
            case 0:
              this.model.legs[index] = `${index + 1}. ${this.model.legs[index].toString()} - 5 serii 8/5/5/3/3`;
              break;
            case 1:
              this.model.legs[index] = `${index + 1}. ${this.model.legs[index].toString()} - 3 serie 8/6/6`;
              break;
            case 2:
              this.model.legs[index] = `${index + 1}. ${this.model.legs[index].toString()} - 2 serie 15/15`;
              break;
          }
          break;
      }
    }
    for (let index = 0; index < tmpShoulders.length; index++) {
      switch (this.trainings[page].aim) {
        case TrainingAim.MASS:
          switch (index) {
            case 0:
              this.model.shoulders[index] = `${index + 1}. ${this.model.shoulders[index].toString()} - 4 serie 10/8/8/6`;
              break;
            case 1:
              this.model.shoulders[index] = `${index + 1}. ${this.model.shoulders[index].toString()} - 3 serie 10/10/8`;
              break;
            case 2:
              this.model.shoulders[index] = `${index + 1}. ${this.model.shoulders[index].toString()} - 2 serie 12/12/12`;
              break;
          }
          break;
        case TrainingAim.REDUCTION:
          switch (index) {
            case 0:
              this.model.shoulders[index] = `${index + 1}. ${this.model.shoulders[index].toString()} - 3 serie 12/12/12`;
              break;
            case 1:
              this.model.shoulders[index] = `${index + 1}. ${this.model.shoulders[index].toString()} - 3 serie 12/12/12`;
              break;
            case 2:
              this.model.shoulders[index] = `${index + 1}. ${this.model.shoulders[index].toString()} - 3 serie 15/15/12`;
              break;
          }
          break;
        case TrainingAim.STRENGTH:
          switch (index) {
            case 0:
              this.model.shoulders[index] = `${index + 1}. ${this.model.shoulders[index].toString()} - 5 serii 8/6/6/4/3`;
              break;
            case 1:
              this.model.shoulders[index] = `${index + 1}. ${this.model.shoulders[index].toString()} - 2 serie 12/12`;
              break;
            case 2:
              this.model.shoulders[index] = `${index + 1}. ${this.model.shoulders[index].toString()} - 3 serie 15/12/12`;
              break;
          }
          break;
      }
    }
    for (let index = 0; index < tmpBiceps.length; index++) {
      switch (this.trainings[page].aim) {
        case TrainingAim.MASS:
          switch (index) {
            case 0:
              this.model.biceps[index] = `${index + 1}. ${this.model.biceps[index].toString()} - 4 serie 10/8/8/6`;
              break;
            case 1:
              this.model.biceps[index] = `${index + 1}. ${this.model.biceps[index].toString()} - 3 serie 10/10/8`;
              break;
            case 2:
              this.model.biceps[index] = `${index + 1}. ${this.model.biceps[index].toString()} - 2 serie 15/12`;
              break;
          }
          break;
        case TrainingAim.REDUCTION:
          switch (index) {
            case 0:
              this.model.biceps[index] = `${index + 1}. ${this.model.biceps[index].toString()} - 3 serie 15/12/12`;
              break;
            case 1:
              this.model.biceps[index] = `${index + 1}. ${this.model.biceps[index].toString()} - 3 serie 12/12/12`;
              break;
            case 2:
              this.model.biceps[index] = `${index + 1}. ${this.model.biceps[index].toString()} - 2 serie 12/12/12`;
              break;
          }
          break;
        case TrainingAim.STRENGTH:
          switch (index) {
            case 0:
              this.model.biceps[index] = `${index + 1}. ${this.model.biceps[index].toString()} - 3 serie 8/8/6`;
              break;
            case 1:
              this.model.biceps[index] = `${index + 1}. ${this.model.biceps[index].toString()} - 3 serie 8/8/6`;
              break;
            case 2:
              this.model.biceps[index] = `${index + 1}. ${this.model.biceps[index].toString()} - 2 serie 12/12`;
              break;
          }
          break;
      }
    }
    for (let index = 0; index < tmpTriceps.length; index++) {
      switch (this.trainings[page].aim) {
        case TrainingAim.MASS:
          switch (index) {
            case 0:
              this.model.triceps[index] = `${index + 1}. ${this.model.triceps[index].toString()} - 4 serie 10/8/8/8`;
              break;
            case 1:
              this.model.triceps[index] = `${index + 1}. ${this.model.triceps[index].toString()} - 4 serie 12/10/10`;
              break;
            case 2:
              this.model.triceps[index] = `${index + 1}. ${this.model.triceps[index].toString()} - 2 serie 12/10`;
              break;
          }
          break;
        case TrainingAim.REDUCTION:
          switch (index) {
            case 0:
              this.model.triceps[index] = `${index + 1}. ${this.model.triceps[index].toString()} - 3 serie 12/12/12`;
              break;
            case 1:
              this.model.triceps[index] = `${index + 1}. ${this.model.triceps[index].toString()} - 3 serie 15/12/12`;
              break;
            case 2:
              this.model.triceps[index] = `${index + 1}. ${this.model.triceps[index].toString()} - 2 serie 15/12/12`;
              break;
          }
          break;
        case TrainingAim.STRENGTH:
          switch (index) {
            case 0:
              this.model.triceps[index] = `${index + 1}. ${this.model.triceps[index].toString()} - 4 serie 10/8/8/8`;
              break;
            case 1:
              this.model.triceps[index] = `${index + 1}. ${this.model.triceps[index].toString()} - 4 serie 12/10/10/10`;
              break;
            case 2:
              this.model.triceps[index] = `${index + 1}. ${this.model.triceps[index].toString()} - 2 serie 12/10`;
              break;
          }
          break;
      }
    }
    for (let index = 0; index < tmpAbs.length; index++) {
      switch (this.trainings[page].aim) {
        case TrainingAim.MASS:
          switch (index) {
            case 0:
              this.model.abs[index] = `${index + 1}. ${this.model.abs[index].toString()} - 3 serie 15/15/15`;
              break;
            case 1:
              this.model.abs[index] = `${index + 1}. ${this.model.abs[index].toString()} - 3 serie 15/15/15`;
              break;
            case 2:
              this.model.abs[index] = `${index + 1}. ${this.model.abs[index].toString()} - 3 serie 20/20/20`;
              break;
          }
          break;
        case TrainingAim.REDUCTION:
          switch (index) {
            case 0:
              this.model.abs[index] = `${index + 1}. ${this.model.abs[index].toString()} - 3 serie 15/20/20`;
              break;
            case 1:
              this.model.abs[index] = `${index + 1}. ${this.model.abs[index].toString()} - 3 serie 15/15/15`;
              break;
            case 2:
              this.model.abs[index] = `${index + 1}. ${this.model.abs[index].toString()} - 3 serie 15/20/25`;
              break;
          }
          break;
        case TrainingAim.STRENGTH:
          switch (index) {
            case 0:
              this.model.abs[index] = `${index + 1}. ${this.model.abs[index].toString()} - 3 serie 15/15/15`;
              break;
            case 1:
              this.model.abs[index] = `${index + 1}. ${this.model.abs[index].toString()} - 3 serie 15/15/15`;
              break;
            case 2:
              this.model.abs[index] = `${index + 1}. ${this.model.abs[index].toString()} - 2 serie 20/20`;
              break;
          }
          break;
      }
    }
    this.ifTraining = true;
  }
}

class ExerciseViewModel {
  constructor(
    public days: number,
    public chest: string[],
    public back: string[],
    public legs: string[],
    public shoulders: string[],
    public biceps: string[],
    public triceps: string[],
    public abs: string[],
  ) { }
}

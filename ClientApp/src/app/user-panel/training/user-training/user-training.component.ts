import { Component, OnInit } from '@angular/core';
import { Training } from 'src/app/shared/models/training.interface';
import { Exercise, Muscle } from 'src/app/shared/models/exercise.interface';
import { TrainingService } from 'src/app/shared/services/training.service';

@Component({
  selector: 'app-user-training',
  templateUrl: './user-training.component.html',
  styleUrls: ['./user-training.component.scss']
})
export class UserTrainingComponent implements OnInit {

  training: Training;
  model: ExerciseViewModel;

  constructor(private trainingService: TrainingService) { }

  ngOnInit() {
    this.trainingService.get().subscribe(training => {
      this.training = training;

      const tmpChest = new Array<Exercise>();
      const tmpBack = new Array<Exercise>();
      const tmpLegs = new Array<Exercise>();
      const tmpShoulders = new Array<Exercise>();
      const tmpTriceps = new Array<Exercise>();
      const tmpBiceps = new Array<Exercise>();
      const tmpAbs = new Array<Exercise>();

      training.exercises.forEach(element => {
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
        tmpChest.map(c => c.name),
        tmpBack.map(b => b.name),
        tmpLegs.map(l => l.name),
        tmpShoulders.map(s => s.name),
        tmpBiceps.map(b => b.name),
        tmpTriceps.map(t => t.name),
        tmpAbs.map(a => a.name)
      );
    });
  }
}

class ExerciseViewModel {
  constructor(
    public chest: string[],
    public back: string[],
    public legs: string[],
    public shoulders: string[],
    public biceps: string[],
    public triceps: string[],
    public abs: string[],
    ) { }
}

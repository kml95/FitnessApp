import { Meals } from './Meals.interface';

export interface Diet {
    dietName: string;
    mealsAmount: number;
    created: string;
    calories: number;
    userName: string;
    meals: Meals [];
}



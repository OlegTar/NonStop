import { Specialization } from "./specialization";

export interface University {
    id?: number;
    name: string;
    description: string;
    specializations: Specialization[];
}
import { Specialization } from "./specialization";

export interface University {
    id?: number;
    name: string;
    description: string;
    site: string,
    minScore: number,
    averageScore: number,
    specializations: Specialization[];
}
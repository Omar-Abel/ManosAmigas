export interface Activity {
    id: number;
    title: string;
    description: string;
    category: string;
    location: string;
    meetingPoint: string;
    peopleRequired: string;
    benefits: string;
    startDate: Date;
    endDate: Date;
    imagePath: string;
    hostId: number;
}

export interface ActivityResponse {
    title: string;
    description: string;
    category: string;
    location: string;
    meetingPoint: string;
    peopleRequired: string;
    benefits: string;
    startDate: Date;
    endDate: Date;
    image: File;
    hostId: number;
}
   
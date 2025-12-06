export interface Image {
    imageUrl: string;
    caption: string;
    altText: string;
    additionalInfo: string;
    projectId: number;
}

export interface ImageAddRequest {
    imageUrl: string;
    caption: string;
    altText: string;
    additionalInfo: string;
}

export interface Project {
    title: string;
    shortDescription: string;
    fullDescription: string;
    projectURL: string;
    dateCreatedFormatted: string;
    gitHubViews: string;
    gitHubRepoName: string;
    images: Image[];
}

export interface AdminProject {
    projectId: number;
    title: string;
    description: string;
    projectURL: string;
    dateCreatedFormatted: string;
    gitHubViews: string;
    gitHubRepoName: string;
    images: Image[];
}

export interface ProjectAddRequest {
    title: string;
    description: string;
    projectURL: string;
    gitHubRepoName: string;
    images: ImageAddRequest[];
}
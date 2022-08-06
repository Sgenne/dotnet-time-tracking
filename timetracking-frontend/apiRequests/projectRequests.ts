import { baseUrl, sendGetRequest, sendPostRequest } from ".";
import Project from "../types/domain/Project";
import Result from "../utils/Result";

const BASE_PROJECTS_URL = `${baseUrl}/project`;

export const getUserProjects = (
  accessToken: string
): Promise<Result<Project[]>> =>
  sendGetRequest<Project[]>({
    url: BASE_PROJECTS_URL,
    accessToken: accessToken,
  });

export const createProject = (accessToken: string, project: Project) =>
  sendPostRequest<Project>({
    url: BASE_PROJECTS_URL,
    accessToken: accessToken,
    data: project,
  });

export const getProjectById = (accessToken: string, projectId: number) =>
  sendGetRequest<Project>({
    url: `${BASE_PROJECTS_URL}/${projectId}`,
    accessToken: accessToken,
  });

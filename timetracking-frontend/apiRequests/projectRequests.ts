import { baseUrl, sendGetRequest } from ".";
import Project from "../types/domain/Project";
import Result from "../utils/Result";

const BASE_PROJECTS_URL = `${baseUrl}/project`;

export const getUserProjects = (
  accessToken: string
): Promise<Result<Project[]>> =>
  sendGetRequest<Project[]>({
    url: BASE_PROJECTS_URL,
    accessToken: accessToken,
    successMessage: "Projects fetched successfully.",
  });

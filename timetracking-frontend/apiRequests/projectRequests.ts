import axios, { AxiosResponse } from "axios";
import { baseUrl, sendGetRequest, sendPostRequest } from ".";
import Project from "../types/domain/Project";
import Result, { resultFromAxiosError } from "../utils/Result";

const BASE_PROJECTS_URL = `${baseUrl}/project`;

export const getUserProjects = (
  accessToken: string
): Promise<Result<Project[]>> =>
  sendGetRequest<Project[]>({
    url: BASE_PROJECTS_URL,
    accessToken: accessToken,
    successMessage: "Projects fetched successfully.",
  });

// export const getUserProjects = async (
//   accessToken: string
// ): Promise<Result<Project[]>> => {
//   let projectsResult: AxiosResponse<Project[]>;
//   try {
//     projectsResult = await axios.get<Project[]>(
//       "http://localhost:8080/project",
//       {
//         headers: {
//           Authorization: `Bearer ${accessToken}`,
//         },
//       }
//     );
//   } catch (error) {
//     return resultFromAxiosError(error);
//   }

//   return {
//     value: projectsResult.data,
//     status: projectsResult.status,
//     message: "Fetched projects successfully.",
//   };
// };

import axios, { AxiosResponse } from "axios";
import { baseUrl, sendPostRequest } from ".";
import Project from "../types/domain/Project";
import Result from "../utils/Result";

const BASE_PROJECTS_URL = `${baseUrl}/project`;

export const getProjects = (accessToken: string) => sendPostRequest()

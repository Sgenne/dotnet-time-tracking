import { useCallback, useEffect, useState } from "react";
import { createProject, getUserProjects } from "../apiRequests/projectRequests";
import Project from "../types/domain/Project";
import Result from "../utils/Result";
import StatusCode from "../utils/StatusCodes";

export interface ProjectHandlerProps {
  accessToken: string;
}

const useProjectHandler = () => {
  const [accessToken, setAccessToken] = useState<string>();
  const [userProjects, setUserProjects] = useState<Project[]>([]);
  const [error, setError] = useState<string>();

  const fetchProjects = useCallback(async () => {
    if (!accessToken) return;

    const fetchResult: Result<Project[]> = await getUserProjects(accessToken);

    if (!(fetchResult.value && fetchResult.status === StatusCode.OK)) {
      setError(fetchResult.message);
      return;
    }

    setError(undefined);
    setUserProjects(fetchResult.value);
  }, [accessToken]);

  useEffect(() => {
    fetchProjects();
  }, [accessToken, fetchProjects]);

  const createProjectHandler = async (
    newProject: Project
  ): Promise<Result<Project>> => {
    if (!accessToken)
      return {
        message: "No access token was available.",
        status: StatusCode.BAD_REQUEST,
      };

    const result = await createProject(accessToken, newProject);

    if (result.status !== StatusCode.CREATED) setError(result.message);
    else fetchProjects();

    return result;
  };

  return {
    setAccessToken,
    userProjects,
    error,
    createProjectHandler,
  };
};

export default useProjectHandler;

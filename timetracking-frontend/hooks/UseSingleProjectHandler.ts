import { useCallback, useEffect, useState } from "react";
import { getProjectById } from "../apiRequests/projectRequests";
import Project from "../types/domain/Project";
import Result from "../utils/Result";
import StatusCode from "../utils/StatusCodes";

const UseSingleProjectHandler = () => {
  const [project, setProject] = useState<Project>();
  const [error, setError] = useState<string>();

  const loadProject = useCallback(
    async (projectId: number, accessToken: string) => {
      const { value, status, message }: Result<Project> = await getProjectById(
        accessToken,
        projectId
      );

      if (!value || status !== StatusCode.OK) {
        setError(message);
        return;
      }

      setProject(value);
      setError(undefined);
    },
    []
  );

  return {
    loadProject,
    project,
    error,
  };
};

export default UseSingleProjectHandler;

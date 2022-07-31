import { useEffect, useState } from "react"
import { getUserProjects } from "../apiRequests/projectRequests"
import ProjectPageComponent from "../components/projects/ProjectsPageComponent"
import { useAuthContext } from "../context/AuthContext"
import withAuthentication from "../higherOrderComponents/WithAuthentication"
import useStringInput from "../hooks/useStringInput"
import ControlledStateHandler from "../types/ControlledStateHandler"
import Project from "../types/domain/Project"
import { resultFromAxiosError } from "../utils/Result"
import StatusCode from "../utils/StatusCodes"

const Projects = () => {
    const [userProjects, setUserProjects] = useState<Project[]>();
    const [errorMessage, setErrorMessage] = useState<string>();

    const { isSignedIn, getAccessToken } = useAuthContext();

    useEffect(() => {
        if (!isSignedIn) return;

        const fetchUserProjects = async () => {
            const accessToken = getAccessToken();
            const { value: fetchedUserProjects, status } = await getUserProjects(accessToken);

            if (!(fetchedUserProjects && status === StatusCode.OK)) {
                // Todo: redirect to error page.
                setErrorMessage("The projects could not be loaded.")
                return;
            }

            setUserProjects(fetchedUserProjects);
            setErrorMessage(undefined);
        }

        fetchUserProjects();

    }, [isSignedIn, getAccessToken])


    const newProjectNameStateHandler: ControlledStateHandler<string> =
        useStringInput();
    const newProjectDescriptionStateHandler: ControlledStateHandler<string> =
        useStringInput();


    console.log("userProjects: ", userProjects);

    return <ProjectPageComponent
        newProjectNameStateHandler={newProjectNameStateHandler}
        newProjectDescriptionHandler={newProjectDescriptionStateHandler} />
}

export default withAuthentication(Projects)
import { useRouter } from "next/router"
import { useEffect, useState } from "react"
import { withDefaultLayout } from "../../components/layouts/DefaultLayout"
import ProjectsPageComponent from "../../components/projects/ProjectsPageComponent"
import { useAuthContext } from "../../context/AuthContext"
import withAuthentication from "../../higherOrderComponents/WithAuthentication"
import useProjectHandler from "../../hooks/UseProjectHandler"
import useStringInput from "../../hooks/useStringInput"
import ControlledStateHandler from "../../types/ControlledStateHandler"
import Project from "../../types/domain/Project"
import { validateNonEmptyString } from "../../utils/validators/NonEmptyStringValidator"

const Projects = () => {
  const [showNewProjectModal, setShowNewProjectModal] = useState(false);
  const router = useRouter();


  const {
    userProjects,
    setAccessToken: setProjectHandlerAccessToken,
    error: projectHandlerError,
    createProjectHandler, } = useProjectHandler();
  const { getAccessToken } = useAuthContext();

  useEffect(() => {
    const accessToken = getAccessToken();
    setProjectHandlerAccessToken(accessToken)
  }, [getAccessToken, setProjectHandlerAccessToken])

  const newProjectNameStateHandler: ControlledStateHandler<string> =
    useStringInput({ validator: validateNonEmptyString });
  const newProjectDescriptionStateHandler: ControlledStateHandler<string> =
    useStringInput();

  const newProjectSubmitHandler = async () => {
    const projectTitle = newProjectNameStateHandler.value;
    const projectDescription = newProjectDescriptionStateHandler.value;

    const newProject: Project = { title: projectTitle, description: projectDescription };

    await createProjectHandler(newProject);

    setShowNewProjectModal(false);
  }

  const projectClickHandler = (project: Project) => {
    if (!project.id) return;
    router.push(`/projects/${project.id}`);
  }

  const newProjectModalOpenHandler = () => setShowNewProjectModal(true);
  const newProjectModalCloseHandler = () => setShowNewProjectModal(false);

  return <ProjectsPageComponent
    newProjectNameStateHandler={newProjectNameStateHandler}
    newProjectDescriptionHandler={newProjectDescriptionStateHandler}
    userProjects={userProjects}
    onCreateNewProject={newProjectSubmitHandler}
    errorMessage={projectHandlerError}
    showNewProjectModal={showNewProjectModal}
    onNewProjectModalClose={newProjectModalCloseHandler}
    onNewProjectModalOpen={newProjectModalOpenHandler}
    onProjectClick={projectClickHandler} />
}

export default withAuthentication(withDefaultLayout(Projects));
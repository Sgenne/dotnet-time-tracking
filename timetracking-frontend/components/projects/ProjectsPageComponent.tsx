import { JSXElementConstructor, ReactElement, useState } from "react";
import styles from "../../styles/projects/ProjectsPageComponent.module.css";
import ControlledStateHandler from "../../types/ControlledStateHandler";
import Project from "../../types/domain/Project";
import PrimaryButton from "../utils/buttons/PrimaryButton";
import PlusIcon from "../utils/icons/PlusIcon";
import LoadingSpinner from "../utils/loading/LoadingSpinner";
import Table, { TableItem } from "../utils/Table";
import NewProjectModal from "./NewProjectModal";

export interface ProjectPageComponentProps {
    newProjectNameStateHandler: ControlledStateHandler<string>;
    newProjectDescriptionHandler: ControlledStateHandler<string>;
    userProjects: Project[];
}

const ProjectPageComponent = ({ newProjectNameStateHandler, newProjectDescriptionHandler, userProjects }: ProjectPageComponentProps) => {
    const [showNewProjectModal, setShowNewProjectModal] = useState(false);

    const newProjectClickHandler = () => setShowNewProjectModal(true);
    const newProjectCloseHandler = () => setShowNewProjectModal(false);

    const projectTableItems: TableItem[] = userProjects.map(project => ({
        Project: project.title,
        "Time Status": "7h"
    }))

    return (
        <div className={styles["page-container"]}>
            {
                showNewProjectModal ? <NewProjectModal
                    nameStateHandler={newProjectNameStateHandler}
                    descriptionStateHandler={newProjectDescriptionHandler}
                    onClose={newProjectCloseHandler} /> : <></>
            }
            <div className={styles["top-bar"]}>
                <h2>Projects</h2>
                <span className={styles["new-project-button-container"]}>
                    <PrimaryButton onClick={newProjectClickHandler}>
                        <>
                            <PlusIcon />
                            <span className={styles["new-project-button__text"]}>New Project</span>
                        </>
                    </PrimaryButton>
                </span>
            </div>
            {
                userProjects
                    ?
                    <div className={styles["projects-table"]}>
                        <Table tableItems={projectTableItems} />
                    </div>
                    :
                    <LoadingSpinner />
            }
        </div>
    )
}

export default ProjectPageComponent
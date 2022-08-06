import { useRouter } from 'next/router'
import React, { useEffect } from 'react'
import { withDefaultLayout } from '../../components/layouts/DefaultLayout';
import SingleProjectPageComponent from '../../components/projects/SingleProjectPageComponent';
import BlackLoadingSpinner from '../../components/utils/loading/BlackLoadingSpinner';
import LoadingSpinner from '../../components/utils/loading/LoadingSpinner';
import { useAuthContext } from '../../context/AuthContext';
import withAuthentication from '../../higherOrderComponents/WithAuthentication';
import UseSingleProjectHandler from '../../hooks/UseSingleProjectHandler';

const SingleProject = () => {
  const router = useRouter();
  const authContext = useAuthContext();
  const { projectId } = router.query;

  const { project, loadProject, error } = UseSingleProjectHandler();

  useEffect(() => {
    if (!projectId) return;

    const accessToken = authContext.getAccessToken();
    loadProject(+projectId, accessToken);
  }, [authContext, projectId, loadProject]);

  if (!projectId) return <BlackLoadingSpinner />

  if (!project) return <div>
    <LoadingSpinner />
  </div>

  return <SingleProjectPageComponent project={project} />
}

export default withAuthentication(withDefaultLayout(SingleProject))